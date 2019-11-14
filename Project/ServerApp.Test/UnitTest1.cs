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
            
            serverDataRuntime.AddToken(new Token(){JwtToken = "Good"});
            var good = serverDataRuntime.CheckToken(new Token(){JwtToken = "Good"});
            var bad = serverDataRuntime.CheckToken(new Token(){JwtToken = "BAD"});
            Assert.True(good);
            Assert.False(bad);
        }
        
        [Fact]
        
        public void TestOverrideLoginUsers()
        {
            var serverDataRuntime = new ServerDataRuntime();
            var token1 = new Token() {JwtToken = "token"};
            var token2 = new Token() {JwtToken = "token"};

            serverDataRuntime.AddToken(token1);
            serverDataRuntime.AddToken(token2);
            var count = serverDataRuntime.getToken(token1).Count;
            Assert.Equal(1,count);
        }
        
   


    }
}
