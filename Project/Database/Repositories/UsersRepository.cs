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
    
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        private SQLiteContext SqLiteContext => Context as SQLiteContext;
        
        public UsersRepository(DbContext context) : base(context)
        {
        }

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