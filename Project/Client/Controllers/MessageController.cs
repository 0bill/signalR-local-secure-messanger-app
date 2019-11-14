using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Contact;
using Client.Data;
using Client.Exceptions;
using Client.Helpers;
using Client.Views;
using Client.Views.Events;
using Domain;
using Unity;
using Message = Domain.Message;

namespace Client.Controllers
{
    public interface IMessageController
    {
        Task LoadMessages();
        void TalksWithUser(User talkWith);
    }

    public class MessageController : GenericController<IMessageView>, IMessageController
    {
        private readonly IUnityContainer _container;
        private User _talksWithUser;
        private readonly IClientDataRuntime _dataRuntime;
        private int _conversationId;

        public MessageController(IUnityContainer container, IMessageView view, IClientDataRuntime dataRuntime) :
            base(view)
        {
            _dataRuntime = dataRuntime;
            _container = container;
            View.OnMessageSend += OnMessageSend;
            EventHelper.OnIncomingMessage += AddIncomingMessage;
            EventHelper.GlobalUserLoggedOff += Close;
        }

        private void AddIncomingMessage(object sender, EventArgs e)
        {
            var sendMessageArgs = (SendMessageArgs) e;
            if (sendMessageArgs.MessageObject == null) return;
            if (sendMessageArgs.MessageObject.ConversationId == _conversationId)
            {
                var message = sendMessageArgs.MessageObject;
                _container.Resolve<ISignalRContext>().MessageReceived(message);
                if (message.AuthorId == _dataRuntime.CurrentUser.Id)
                {
                    View.AddSentMessage(message.DecryptText(), message.Timestamp);
                }
                else
                {
                    View.AddIncomingMessage(message.DecryptText(), message.Timestamp);
                }
            }
        }

        private void OnMessageSend(object sender, EventArgs e)
        {
            var onSendMessage = (SendMessageArgs) e;
            var message = new Domain.Message();
            message.AuthorId = _dataRuntime.CurrentUser.Id;
            message.ConversationId = _conversationId;
            message.EncryptText(onSendMessage.Message);

            _container.Resolve<ISignalRContext>().SendMessage(message);
        }




        private void Close(object sender, EventArgs e)
        {
            View.CloseView();
            Dispose();
        }


        private protected override void View_Closed(object sender, EventArgs e)
        {
            Dispose();
        }

        protected override void Dispose()
        {
            Console.WriteLine(this.GetHashCode());
            _container.Resolve<ObjectContainer>().DisposeObject(View);
            _container.Resolve<ObjectContainer>().DisposeObject(this);
            EventHelper.GlobalUserLoggedOff -= Close;
            EventHelper.OnIncomingMessage -= AddIncomingMessage;
            GC.Collect();
            base.Dispose();
        }


        public User TalksWithUser()
        {
            return _talksWithUser;
        }

        public async Task LoadMessages()
        {
            var converstationUsers = new List<User>();

            converstationUsers.Add(new User
                {Id = _dataRuntime.CurrentUser.Id, Username = _dataRuntime.CurrentUser.Username});
            converstationUsers.Add(new User {Id = _talksWithUser.Id, Username = "Dump"});
            Console.WriteLine("start");


            try
            {
                var restApiContext = _container.Resolve<RestApiContext>()
                    .EstablishConnection(_dataRuntime.CurrentUser.Token);
                var postGetConversation = await restApiContext.PostGetConversation(converstationUsers);
                _conversationId = postGetConversation.Id;
                var messages = await restApiContext.PostGetAllMessagesForConversation(_conversationId);
                Console.WriteLine(_dataRuntime.CurrentUser.Token.JwtToken);
                if (messages == null)
                {
                    messages = new List<Message>();
                }


                foreach (var message in messages)
                {
                    if (message.Author.Id == _dataRuntime.CurrentUser.Id)
                    {
                        View.AddSentMessage(message.DecryptText(), message.Timestamp);
                    }
                    else
                    {
                        View.AddIncomingMessage(message.DecryptText(), message.Timestamp);
                    }
                }
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(DataNotFoundException))
                {
                    MessageBox.Show(e.Message);
                }

                Console.WriteLine(e);
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("end");
        }

        public void Activate()
        {
            this.View.Activate();
        }

        public void TalksWithUser(User talkWith)
        {
            _talksWithUser = talkWith;
            View.InitUser(_talksWithUser.Username);
        }
    }
}