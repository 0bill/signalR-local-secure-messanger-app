using System;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsLoginUserValid(User userToLogin);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public SQLiteContext SqLiteContext => Context as SQLiteContext;

        public UserRepository(DbContext context) : base(context)
        {
        }

        public bool IsLoginUserValid(User userToLogin)
        {
            var result = SqLiteContext.Users.SingleOrDefault(u => u.Username == userToLogin.Username);
            return result != null;
            
        }
    }
}