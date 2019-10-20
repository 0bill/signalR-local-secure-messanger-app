using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Contact;
using Client.Data;
using Client.Helpers;
using Client.Views;
using Client.Views.Events;
using Unity;

namespace Client.Controllers
{
    public interface IHomeController
    {
        IHomePanelView GetStartGetView();
        void LogoutUser();
    }

    class HomeController : GenericController<IHomePanelView>, IHomeController
    {
        private IUnityContainer _container;
        private User CurrentUser;

        public HomeController(IUnityContainer unityContainer, IHomePanelView view) : base(view)
        {
            CurrentUser = null;
            
            _container = unityContainer;
            view.UserLoginSubmit += LoginUser;
            
        }

        private async void LoginUser(object sender, EventArgs e)
        {
            var userSubmit = (OnUserSubmitEventArgs) e;
            var providedUser = new User
            {
                Username = userSubmit.Username,
                NotHashedPassword = userSubmit.Password
            };
            View.ShowLoginMessage("Loading...");
            
            try
            {
                var post = await _container.Resolve<IRestApiContext>().EstablishConnection().PostAuthUser(providedUser);
                if (post != null)
                {
                    CurrentUser = post;
                    OnSuccessLogin(); 
                }
                    
            }
            catch(Exception exception)
            {
                if (typeof(System.Net.Http.HttpRequestException) == exception.GetType())
                {
                    View.ShowLoginError("Cannot connect to the server. Try again later");
                }
                return;
            }
            
            View.ShowLoginError("Wrong user");
        }
        
        

        private async void OnSuccessLogin()
        {
            var post = await _container.Resolve<IRestApiContext>().EstablishConnection().PostGetAllUsers(CurrentUser.getToken());
            post.Remove(post.SingleOrDefault(x=>x.Id==CurrentUser.Id));
            View.UserLoggedOn();
            View.OnUserClick += OnUserClick;
            View.LogoutUser += LogoutUser;
            LoadUsersTopPanel(post);
        }

        public void LogoutUser()
        {
            CurrentUser = null;
            View.UserLoggedOFF();
            View.OnUserClick -= OnUserClick;
            View.LogoutUser -= LogoutUser;
            EventHelper.RaiseGlobalUserLoggedOff(this,EventArgs.Empty);
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
            EventHelper.Raise(this, new EventArgs());
            var talkWith = ((Control) sender).Name;

            var checkIsInstanceExit = _container.Resolve<ObjectContainer>().CheckMessageIsInstanceExit(talkWith);
            Console.WriteLine(checkIsInstanceExit);
            if (checkIsInstanceExit == null)
            {
                var messageController = _container.Resolve<IMessageController>();
                messageController.TalksWithUser(talkWith);
            }
            else
            {
                checkIsInstanceExit.Activate();
            }
        }

        public IHomePanelView GetStartGetView()
        {
            return View;
        }

        

        public void runTest()
        {
            //ITestController tempTestView = container.Resolve<TestController>();

            //passing values to constructor
            /*
            ITestPresenter tempTestView = container.Resolve<TestPresenter>(new ResolverOverride[]
            {
                new ParameterOverride("cn", container)
                //new ParameterOverride("view", container.Resolve<ITestView>())
            });
            */

            //tempTestView.GetView().show();

            //opt 2


            //_testView.getSub().show();
        }

        private protected override void View_Closed(object sender, EventArgs e)
        {
        }
    }
}