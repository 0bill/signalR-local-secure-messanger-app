using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    
    public interface IConversationRepository : IRepository<Conversation>
    {
        Conversation GetConversation(int user1Id, int user2Id);
        Conversation CreateNewConversation(int user1Id, int user2Id);
        List<int> GetConversationUsers(int newMessageConversationId);
    }
    
    /// <summary>
    /// Processes sql queries for conversations
    /// </summary>
    public class ConversationRepository : Repository<Conversation>, IConversationRepository
    {
        private SQLiteContext SqLiteContext => Context as SQLiteContext;
        
        public ConversationRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Return conversation between two users
        /// </summary>
        /// <param name="user1Id"></param>
        /// <param name="user2Id"></param>
        /// <returns></returns>
        public Conversation GetConversation(int user1Id, int user2Id)
        {
            var result = SqLiteContext.ConversationUsers
                .Join(SqLiteContext.ConversationUsers, cu => cu.ConversationId, cc => cc.ConversationId,
                    (cu, cc) => new {cu, cc})
                .Where(@t => @t.cu.UserId == user1Id && @t.cc.UserId == user2Id)
                .Select(@t => new Conversation(){Id=@t.cu.ConversationId})
                .SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Create new conversation between users
        /// </summary>
        /// <param name="user1Id"></param>
        /// <param name="user2Id"></param>
        /// <returns></returns>
        public Conversation CreateNewConversation(int user1Id, int user2Id)
        {
            var user1 = SqLiteContext.Users.SingleOrDefault(u => u.Id == user1Id);
            if (user1 == null) return null;
            var user2 = SqLiteContext.Users.SingleOrDefault(u => u.Id == user2Id);
            if (user2 == null) return null;
            var conversation = new Conversation {Messages = null, ConversationUsers = new List<ConversationUser>()};
            var conversationUser1 = new ConversationUser {UserId = user1.Id, User = user1};
            var conversationUser2 = new ConversationUser {UserId = user2.Id, User = user2};
            conversation.ConversationUsers.Add(conversationUser1);
            conversation.ConversationUsers.Add(conversationUser2);
            var entityEntry = SqLiteContext.Conversations.Add(conversation);            
            SqLiteContext.SaveChanges();
            var entityEntryEntity = entityEntry.Entity;
            return entityEntryEntity;
        }

        /// <summary>
        /// Returns list of users ids for conversation
        /// </summary>
        /// <param name="newMessageConversationId"></param>
        /// <returns></returns>
        public List<int> GetConversationUsers(int newMessageConversationId)
        {
            return SqLiteContext.ConversationUsers.Where(x=>x.ConversationId == newMessageConversationId).Select(x=>x.UserId).ToList();
            
        }
    }
}