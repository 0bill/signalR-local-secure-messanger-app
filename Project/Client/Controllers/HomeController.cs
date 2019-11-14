using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Contact;
using Client.Data;
using Client.Exceptions;
using Client.Helpers;
using Client.Views;
using Client.Views.Events;
using Newtonsoft.Json;
using Unity;
using Message = Domain.Message;

namespace Client.Controllers
{
    public interface IHomeController
    {
        Form GetView();
    }

    class HomeController : GenericController<IHomePanelView>, IHomeController
    {
        private IUnityContainer _container;
        private IClientDataRuntime _dataRuntime;

        public HomeController(IUnityContainer unityContainer, IHomePanelView view, IClientDataRuntime dataRuntime) :
            base(view)
        {
            _dataRuntime = dataRuntime;
            _dataRuntime.CurrentUser = null;
            _container = unityContainer;
            view.UserLoginSubmit += LoginUser;
            EventHelper.PlayIncomingSound += IncomeSound;
        }
        
        private void IncomeSound(object sender, EventArgs e)
        { 

            var sendMessageArgs = (SendMessageArgs) e;
            if (sendMessageArgs.MessageObject == null) return;
            if (sendMessageArgs.MessageObject.AuthorId != _dataRuntime.CurrentUser.Id)
            {
                new System.Media.SoundPlayer(@"C:\Users\16pxd\Desktop\91926__tim-kahn__ding.wav").Play();

            }

        }

        
        private async void LoginUser(object sender, EventArgs e)
        {
            var userSubmit = (SubmitUserArgs) e;
            var providedUser = new User
            {
                Username = userSubmit.Username,
                NotHashedPassword = userSubmit.Password,
                Token = new Token()
            };
            View.ShowLoginMessage("Loading...");

            try
            {
                var restApiContext = _container.Resolve<IRestApiContext>();
                var establishConnection =  restApiContext.EstablishConnection(null);
                var post = await establishConnection.PostAuthUser(providedUser);
                if (post == null) View.ShowLoginError("Something went wrong..");;
                _dataRuntime.CurrentUser = post;
                OnSuccessLogin();

            }
            catch (Exception exception)
            {
                if (typeof(HttpRequestException) == exception.GetType())
                {
                    View.ShowLoginError("Cannot connect to the server. Try again later");
                }

                if (typeof(DataNotFoundException) == exception.GetType())
                {
                    View.ShowLoginError("Wrong user");
                }
                
                Console.WriteLine(exception);
                
            }
            

            
        }


        private async void OnSuccessLogin()
        {
            var post = await _container.Resolve<IRestApiContext>()
                .EstablishConnection(_dataRuntime.CurrentUser.Token)
                .PostGetAllUsers();
            post?.Remove(post.SingleOrDefault(x => x.Id == _dataRuntime.CurrentUser.Id));
            _dataRuntime.UserList = post;
            View.UserLoggedOn();
            View.OnUserClick += OnUserClick;
            View.LogoutUser += LogoutUser;
            EventHelper.GlobalUserLoggedOff += LogoutUser;
            LoadUsersTopPanel(_dataRuntime.UserList);
            _container.Resolve<ISignalRContext>().EstablishConnection(_dataRuntime.CurrentUser.Token);
            
        }

        private void LogoutUser()
        {
            View.OnUserClick -= OnUserClick;
            View.LogoutUser -= LogoutUser;
            _dataRuntime.CurrentUser = null;
            View.UserLoggedOFF();
            _container.Resolve<ISignalRContext>().Dispose();
            _container.Resolve<ObjectContainer>().Clear();
        }

        private void LogoutUser(object sender, EventArgs e)
        {
            LogoutUser();
        }


        private void LoadUsersTopPanel(List<User> users)
        {
            View.FillPanelWithUsers(users);
        }


        private void OnUserClick(object sender, EventArgs e)
        {

            var talkWithUser = _dataRuntime.UserList.SingleOrDefault(user => user.Id == Convert.ToInt32(((Control) sender).Name));
                
            
            var checkIsInstanceExit = _container.Resolve<ObjectContainer>()
                .CheckMessageIsInstanceExit(talkWithUser);

            if (checkIsInstanceExit == null)
            {
                var messageController = _container.Resolve<IMessageController>();
                messageController.TalksWithUser(talkWithUser);
                messageController.LoadMessages();
            }
            else
            {
                checkIsInstanceExit.Activate();
            }
        }


        public new Form GetView()
        {
            return (Form)base.GetView();
        }

        private protected override void View_Closed(object sender, EventArgs e)
        {
           
        }
    }
}