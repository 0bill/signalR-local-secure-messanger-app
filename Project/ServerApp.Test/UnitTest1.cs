using ServerApp.Data;
using System;
using Database;
using Domain;
using ServerApp.Controllers;
using Xunit;

namespace ServerApp.Test
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            
        }
        [Fact]
        public void TestTokenExist()
        {
            var serverDataRuntime = new ServerDataRuntime();
            var user = new User {Id = 1, Username = "admin", Token = "Token"};
            serverDataRuntime.AddConnectedUser(user);
            var good = serverDataRuntime.CheckToken(user.Token);
            var bad = serverDataRuntime.CheckToken("BAD");
            Assert.True(good);
            Assert.False(bad);
        }
        
        [Fact]
        public void TestOverrideLoginUsers()
        {
            var serverDataRuntime = new ServerDataRuntime();
            var user = new User {Id = 1, Username = "admin", Token = "Token"};
            var user2 = new User {Id = 1, Username = "admin", Token = "Token"};
            serverDataRuntime.AddConnectedUser(user);
            serverDataRuntime.AddConnectedUser(user2);
            var count = serverDataRuntime.getConnected().Count;
            Assert.Equal(1,count);
        }

        [Fact]
        public void TestPostGetUsers()
        {
           
            
        }
    }
}
