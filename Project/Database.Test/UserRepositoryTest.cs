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
            var result = unitOfWork.LoginUserRepository.IsLoginUserValid(user);
            user.NotHashedPassword = "BAD";
            var result2 = unitOfWork.LoginUserRepository.IsLoginUserValid(user);

            Assert.True(result!=null);
            Assert.False(result2!=null);
        }

        [Fact]
        public void TestGettingUsers()
        {
            var sqLiteContext = new SQLiteContext();
            IUnitOfWork unitOfWork = new UnitOfWork(sqLiteContext);
            var listUsersDescending = unitOfWork.UsersRepository.GetListUsersDescending();
            foreach (var user in listUsersDescending)
            {
                Output.WriteLine(user.Username);
            }
        }

    

     
    }
}