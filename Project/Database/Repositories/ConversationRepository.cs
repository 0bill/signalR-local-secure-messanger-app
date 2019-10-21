using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    
    public interface IConversationRepository : IRepository<Conversation>
    {
        int getConversation(int clientUserId, int receiverUserId);
        List<Message> getConversationMessages(int ConversationId);
    }
    
    public class ConversationRepository : Repository<Conversation>, IConversationRepository
    {
        public SQLiteContext SqLiteContext => Context as SQLiteContext;
        
        public ConversationRepository(DbContext context) : base(context)
        {
        }

        public int getConversation(int clientUserId, int receiverUserId)
        {
            var result = SqLiteContext.ConversationUsers
                .Join(SqLiteContext.ConversationUsers, cu => cu.ConversationId, cc => cc.ConversationId,
                    (cu, cc) => new {cu, cc})
                .Where(@t => @t.cu.UserId == clientUserId && @t.cc.UserId == receiverUserId)
                .Select(@t => @t.cu.ConversationId)
                .SingleOrDefault();
            return result;
        }

        public List<Message> getConversationMessages(int ConversationId)
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