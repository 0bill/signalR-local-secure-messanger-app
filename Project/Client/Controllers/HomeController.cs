using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        IUnityContainer container;
        private IHomePanelView _view;

        public HomeController(IUnityContainer unityContainer, IHomePanelView view) : base(view)
        {
            var user = new User() {Username = "One"};
            var user2 = new User() {Username = "two"};
            var user3 = new User() {Username = "three"};
            var users = new List<string>();
            users.Add(user.Username);
            users.Add(user2.Username);
            users.Add(user3.Username);
            view.FillPanelWithUsers(users);

            Console.WriteLine("Home" + this.GetHashCode());
            Console.WriteLine("unityContainer" + unityContainer.GetHashCode());
            container = unityContainer;
            _view = view;

            view.OnUserClick += OnUserClick;
        }


        private void OnUserClick(object sender, EventArgs e)
        {
            EventHelper.Raise(this, new EventArgs());
            var talkWith = ((Control) sender).Name;
            Console.WriteLine("***" + sender.ToString());
            Console.WriteLine(">>" + talkWith);

            var checkIsInstanceExit = container.Resolve<ObjectContainer>().CheckMessageIsInstanceExit(talkWith);
            Console.WriteLine(checkIsInstanceExit);
            if (checkIsInstanceExit == null)
            {
                var messageController = container.Resolve<IMessageController>();
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