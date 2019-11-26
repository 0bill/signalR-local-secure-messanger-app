using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetListUsersDescending();
    } 
    
    /// <summary>
    /// Processes sql queries for users
    /// </summary>
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private SQLiteContext SqLiteContext => Context as SQLiteContext;
        
        public UsersRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Returns list of users in descending order
        /// </summary>
        /// <returns></returns>
        public List<User> GetListUsersDescending()
        {
            return SqLiteContext.Users.Select(u => new User()
            {
                Id = u.Id,
                Username = u.Username
            }).ToList();
        }
    }

    
}