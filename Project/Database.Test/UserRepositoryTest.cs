using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Xunit;
using Xunit.Abstractions;

namespace Database.Test
{
    public class UserRepositoryTest : OutputTest
    {
        public UserRepositoryTest(ITestOutputHelper output) : base(output)
        {
        }
        
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
        public void TestUserPassword()
        {
            string password = "test";
            var user = new User()
            {
                Username = "Test",
                Password = password
            };
            Output.WriteLine(user.Password);
            Assert.NotSame(password, user.Password);
        }

     
    }
}