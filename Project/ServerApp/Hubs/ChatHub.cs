using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Database;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ServerApp.Data;

namespace ServerApp.Hubs
{
    /// <summary>
    /// This class represents endpoint for SignalR connections
    /// </summary>
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServerDataRuntime _dataRuntime;

        public ChatHub(IUnitOfWork unitOfWork, IServerDataRuntime serverData)
        {
            // _serviceProvider = serviceProvider;
            _dataRuntime = serverData;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method execute for new connected user
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("IncomingMessage", "Dispose");

            //if (!Context.GetHttpContext().Request.IsHttps) Context.Abort();

            Console.WriteLine("Connected " + Context.ConnectionId);


            var identity = Context.GetHttpContext().User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var userClaimId = claim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var userClaimName = claim.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            int userId = Convert.ToInt32(userClaimId);
            var existingUsers = _dataRuntime.ConntectedUsers.Where(x => x.Id == userId);

            foreach (var existingUser in existingUsers)
            {
                Clients.Client(existingUser.ConnectionId).SendAsync("Abort",1);
            }
            
            _dataRuntime.ConntectedUsers.Add(new User()
            {
                Id = userId,
                Username = userClaimName,
                ConnectionId = Context.ConnectionId
            });


            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Method execute for case user ends connection
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("IncomingMessage", "Dispose");

            Console.WriteLine("Disconnected " + Context.ConnectionId);
            var disconnectedUser =
                _dataRuntime.ConntectedUsers.SingleOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (disconnectedUser != null)
                _dataRuntime.ConntectedUsers.Remove(disconnectedUser);
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Sending message for each user involved to conversation
        /// </summary>
        /// <param name="newMessage"></param>
        public void Send(Message newMessage)
        {
            var singleOrDefault = _dataRuntime.ConntectedUsers.SingleOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if(singleOrDefault==null) Context.Abort();
            //save new message into database
            var addNewMessage = _unitOfWork.MessageRepository.AddNewMessage(newMessage);
    
            //find connected users
            List<int> conversationUsers = _unitOfWork.ConversationRepository.GetConversationUsers(newMessage.ConversationId);
            //send to them new message
            foreach (var conversationUser in conversationUsers)
            {
                var user = _dataRuntime.ConntectedUsers.SingleOrDefault(x=>x.Id == conversationUser);
                if(user!=null)
                    Clients.Client(user.ConnectionId).SendAsync("IncomingMessage", newMessage);
            }

            
        }
        /// <summary>
        /// Method mark received messages as received
        /// </summary>
        /// <param name="message"></param>
        public void ReceivedMessage(Message message)
        {
            var singleOrDefault = _dataRuntime.ConntectedUsers.SingleOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if(singleOrDefault==null) Context.Abort();
            
            var identity = Context.GetHttpContext().User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var userClaim = claim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            int userId = Convert.ToInt32(userClaim);

            List<Message> conversationMessages = new List<Message> {message};
            _unitOfWork.MessageRepository.MarkMessagesAsReceived(userId, conversationMessages);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}