using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> GetConversationMessages(int ConversationId);

    }
    public class MessageRepository : Repository<Message>
    {
        public SQLiteContext SqLiteContext => Context as SQLiteContext;

        public MessageRepository(DbContext context) : base(context)
        {
           
        }
        
        public List<Message> GetConversationMessages(int ConversationId)
        {
            List<Message> messages = (from c in SqLiteContext.Conversations
                join m in SqLiteContext.Messages
                    on c.Id equals m.ConversationId
                where m.ConversationId == ConversationId
                select new Message()
                {
                    Id = m.Id,
                    Text = m.Text,
                    Author = new User()
                    {
                        Id = m.Author.Id,
                        Username = m.Author.Username
                    }

                }).ToList();
            return messages;
        }
    }
}