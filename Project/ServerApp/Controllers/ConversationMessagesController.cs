using System.Collections.Generic;
using Database;
using Domain;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationMessagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServerDataRuntime _dataRuntime;

        public ConversationMessagesController(IUnitOfWork unitOfWork, IServerDataRuntime dataRuntime)
        {
            _unitOfWork = unitOfWork;
            _dataRuntime = dataRuntime;
        }


        // POST: api/ConversationMessages
        [HttpPost]
        public ActionResult<List<Message>> PostConversationMessage(Conversation conversation)
        {
            //var iscorrect = _dataRuntime.CheckToken(token.Key);

            if (true)
            {

                if (conversation != null)
                {
                    List<Message> conversationMessages =
                        _unitOfWork.MessageRepository.GetConversationMessages(conversation.Id);

                    return Ok(conversationMessages);
                }
            }

            return BadRequest();
        }
    }
}