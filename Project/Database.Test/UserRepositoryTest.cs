using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Xunit;

namespace Database.Test
{
    public class UserRepositoryTest
    {
        private readonly DbContextOptions<SQLiteContext> _dbOptions = new DbContextOptionsBuilder<SQLiteContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;

        [Fact]
        public void TestLoginUser()
        {
           var user = new User
            {
                Username = "test",
                Password = "testPassword"
            };

            var sqLiteContext = new SQLiteContext(_dbOptions);
            using var unitOfWork = new UnitOfWork(sqLiteContext);
            sqLiteContext.Users.Add(user);
            sqLiteContext.SaveChanges();
            var isLoginUserValid = unitOfWork.UserRepository.IsLoginUserValid(user);
            
            Assert.True(isLoginUserValid);
        }

        [Fact]
        public void TestCreateUser()
        {
            
        }
        
    }
}