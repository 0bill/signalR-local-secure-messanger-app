﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public interface ILoginUserRepository: IRepository<User>
    {
        User IsLoginUserValid(User userToLogin);
        
    }

    /// <summary>
    /// Processes sql queries for user login
    /// </summary>
    public class LoginUserRepository : Repository<User>, ILoginUserRepository
    {
        public SQLiteContext SqLiteContext => Context as SQLiteContext;

        public LoginUserRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Validate users
        /// </summary>
        /// <param name="userToLogin"></param>
        /// <returns></returns>
        public User IsLoginUserValid(User userToLogin)
        {
            var result = SqLiteContext.Users
                .Where(u => u.Username == userToLogin.Username && u.Password == userToLogin.Password)
                .Select(u => new User()
                {
                    Id = u.Id,
                    Username  = u.Username
                }).SingleOrDefault();
            
            //var old = SqLiteContext.Users.SingleOrDefault(u => u.Username == userToLogin.Username && u.Password == userToLogin.Password);
            
            return result;
            
        }
        
       
    }
}