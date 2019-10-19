using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Contact;
using Client.Helpers;
using Client.Views;
using Unity;

namespace Client.Controllers
{
    public interface IHomeController
    {
        IHomePanelView GetStartGetView();
    }

    class HomeController : GenericController<IHomePanelView>, IHomeController
    {
        private IUnityContainer _container;
        private bool UserSessionActive { get; set; }

        public HomeController(IUnityContainer unityContainer, IHomePanelView view) : base(view)
        {
            UserSessionActive = false;
            LoadUsersTest(view);
            Console.WriteLine("Home" + this.GetHashCode());
            Console.WriteLine("unityContainer" + unityContainer.GetHashCode());
            _container = unityContainer;
            view.UserLoginSubmit += LoginUser;

            view.OnUserClick += OnUserClick;
        }

        private async void LoginUser(object sender, EventArgs e)
        {
            var userSubmit = (OnUserSubmitEventArgs) e;
            var user = new User
            {
                Username = userSubmit.Username,
                Password = userSubmit.Password
            };

            var post = await _container.Resolve<IRestApiContext>().EstablishConnection().Post(user);    
            if(post)
               View.UserLoggedOn(); 
            View.ShowLoginError("Wrong user");
        }

        private static void LoadUsersTest(IHomePanelView view)
        {
            var user = new User() {Username = "One"};
            var user2 = new User() {Username = "two"};
            var user3 = new User() {Username = "three"};
            var users = new List<string>();
            users.Add(user.Username);
            users.Add(user2.Username);
            users.Add(user3.Username);
            view.FillPanelWithUsers(users);
        }


        private void OnUserClick(object sender, EventArgs e)
        {
            EventHelper.Raise(this, new EventArgs());
            var talkWith = ((Control) sender).Name;
            Console.WriteLine("***" + sender.ToString());
            Console.WriteLine(">>" + talkWith);

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