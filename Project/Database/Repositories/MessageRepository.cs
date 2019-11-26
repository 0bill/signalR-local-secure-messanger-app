using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> GetConversationMessages(int ConversationId);

        Task AddNewMessage(Message newMessage);
        void MarkMessagesAsReceived(int userId, List<Message> messages);
        void CheckOldMessages();
    }
    /// <summary>
    /// Processes sql queries for messages
    /// </summary>
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public SQLiteContext SqLiteContext => Context as SQLiteContext;

        public MessageRepository(DbContext context) : base(context)
        {
           
        }
        /// <summary>
        /// Returns all messages for conversation 
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        public List<Message> GetConversationMessages(int conversationId)
        {
            List<Message> messages = (from c in SqLiteContext.Conversations
                join m in SqLiteContext.Messages
                    on c.Id equals m.ConversationId
                where m.ConversationId == conversationId
                select new Message()
                {
                    Id = m.Id,
                    Text = m.Text,
                    Timestamp = m.Timestamp,
                    Author = new User()
                    {
                        Id = m.Author.Id,
                        Username = m.Author.Username
                    }

                }).ToList();
            return messages;
        }
        /// <summary>
        /// Add new messages with current time
        /// </summary>
        /// <param name="newMessage"></param>
        /// <returns></returns>
        public async Task AddNewMessage(Message newMessage)
        {
            newMessage.Timestamp = DateTime.Now;
           await SqLiteContext.Messages.AddAsync(newMessage);
           await SqLiteContext.SaveChangesAsync();
        }
        
        /// <summary>
        /// Mark messages as received
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messages"></param>
        public void MarkMessagesAsReceived(int userId, List<Message> messages)
        {
            
            var list = (from m in messages
                from rm in SqLiteContext.ReceivedMessages
                where m.Id == rm.MessageId && rm.UserId == userId
                select m.Id).ToList();

            var notReceivedList = (from m in messages where !list.Contains(m.Id) select m).ToList();

            foreach (var notReceived in notReceivedList)
            {
                var receivedMessage = new ReceivedMessages()
                {
                    MessageId = notReceived.Id,
                    UserId = userId,
                    Timestamp = DateTime.Now
                };
                SqLiteContext.ReceivedMessages.Add(receivedMessage);
            }

            SqLiteContext.SaveChanges();


        }

        /// <summary>
        /// Check for old messages and delete old ones
        /// </summary>
        public void CheckOldMessages()
        {
            var messageslist = SqLiteContext.Messages.Where(x => x.Timestamp.AddDays(180) <= DateTime.Now).ToList();
            var list = messageslist.Select(x => x.Id);
            var receivedMessageses = (from m in SqLiteContext.ReceivedMessages where !list.Contains(m.Id) select m).ToList();
            
            
            SqLiteContext.ReceivedMessages.RemoveRange(receivedMessageses);
            SqLiteContext.Messages.RemoveRange(messageslist);
            SqLiteContext.SaveChanges();
        }
    }
}