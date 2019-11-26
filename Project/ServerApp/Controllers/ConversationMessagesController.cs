using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Database;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    /// <summary>
    /// Controller handle all request related to messages
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationMessagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConversationMessagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        /// <summary>
        /// Return all messages for conversation and mark as received
        /// </summary>
        /// <param name="conversation"></param>
        /// <returns></returns>
        [HttpPost("messages")]
        public ActionResult<List<Message>> PostConversationMessage(Conversation conversation)
        {
           if (conversation == null) return BadRequest();
            
           
            List<Message> conversationMessages =
                _unitOfWork.MessageRepository.GetConversationMessages(conversation.Id);
            /*
            if (conversationMessages == null) return NotFound();
            return Ok(conversationMessages);*/
            
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = identity.Claims;
            var userClaim = claim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            int userId = Convert.ToInt32(userClaim);
            _unitOfWork.MessageRepository.MarkMessagesAsReceived(userId,conversationMessages);
            return Ok(conversationMessages);


        }
      
        /// <summary>
        /// Returns conversation id for matched users
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("conversation")]
        public ActionResult<Conversation> PostGetConversationBetweenUsers(List<User> users)
        {
            if (users.Count != 2 ) return BadRequest();

            var user1 = users[0];
            var user2 = users[1];
            
            var conversationWithId = _unitOfWork.ConversationRepository.GetConversation(user1.Id, user2.Id);
            //TODO: trzeba stworzyc rozmowe dla uzytkownikow jesli ten drugi istnieje.
            if (conversationWithId != null) return Ok(conversationWithId);
            var newConversation = _unitOfWork.ConversationRepository.CreateNewConversation(user1.Id, user2.Id);
            if (newConversation == null) return BadRequest();


            return Ok(newConversation);
        }
    }
}