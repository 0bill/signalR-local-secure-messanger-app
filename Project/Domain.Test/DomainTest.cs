using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Domain.Test
{
    public class DomainTest
    {
        
        public readonly ITestOutputHelper Output;

        public DomainTest(ITestOutputHelper output)
        {
            this.Output = output;
        }
        [Fact]
        public void TestUserPassword()
        {
            string password = "test";
            var user = new User()
            {
                Username = "Test",
                NotHashedPassword = password
            };
            Assert.NotSame(password, user.Password);
        }

        [Fact]
        public void TestUserTokenAssigment()
        {
           
            var user = new User()
            {
                Id = 1,
                Username = "Test",
                Token = new Token(),
                ConnectionId = "Connid"
            };
            
            Assert.Equal(1,user.Id);
            Assert.Same("Test",user.Username);
            Assert.Same(new Token(), user.Token);
            Assert.Same("Connid",user.ConnectionId);
            
        }
        
        
        [Fact]
        public void GetTokenFromUser()
        {
           
            var user = new User()
            {
                Id = 1,
                Username = "Test",
                //Token = "Token",
                ConnectionId = "Connid"
            };
            
            
        }

        [Fact]
        public void TestMessageTextEncryption()
        {
            var textToEnccrypt = "Text";
            var message = new Message();
            message.EncryptText(textToEnccrypt);
            Output.WriteLine(message.Text);
            Assert.NotEqual(textToEnccrypt, message.Text);
            Assert.Equal(textToEnccrypt, message.DecryptText());
            
        }

        [Fact]
        public void TestMessage()
        {
            var message = new Message()
            {
                Id = 1,
                Text = "Sample"
            };
            
            Output.WriteLine(message.Text);
        }
    }
}
