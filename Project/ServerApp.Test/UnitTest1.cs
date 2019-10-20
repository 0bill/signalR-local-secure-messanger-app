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
            serverDataRuntime.addConnectedUser(user);
            var good = serverDataRuntime.checkToken(user.Token);
            var bad = serverDataRuntime.checkToken("BAD");
            Assert.True(good);
            Assert.False(bad);
        }
        
        [Fact]
        public void TestOverrideLoginUsers()
        {
            var serverDataRuntime = new ServerDataRuntime();
            var user = new User {Id = 1, Username = "admin", Token = "Token"};
            var user2 = new User {Id = 1, Username = "admin", Token = "Token"};
            serverDataRuntime.addConnectedUser(user);
            serverDataRuntime.addConnectedUser(user2);
            var count = serverDataRuntime.getConnected().Count;
            Assert.Equal(1,count);
        }

        [Fact]
        public void TestPostGetUsers()
        {
           
            
        }
    }
}
