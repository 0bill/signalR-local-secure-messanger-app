using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    
    public interface IConversationRepository : IRepository<Conversation>
    {
        int getConversation(int clientUserId, int receiverUserId);
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

       
    }
}