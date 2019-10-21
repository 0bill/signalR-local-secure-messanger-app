using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Test
{
    public class DomainTest
    {
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
                Token = "Token",
                ConnectionId = "Connid"
            };
            
            Assert.Equal(1,user.Id);
            Assert.Same("Test",user.Username);
            Assert.Same("Token",user.Token);
            Assert.Same("Connid",user.ConnectionId);
            
        }
        
        
        [Fact]
        public void GetTokenFromUser()
        {
           
            var user = new User()
            {
                Id = 1,
                Username = "Test",
                Token = "Token",
                ConnectionId = "Connid"
            };
            
            Assert.Same(typeof(Token),user.GetToken().GetType());
            Assert.Same("Token",user.GetToken().Key);
            
        }

        [Fact]
        public void TestMessageTextEncryption()
        {
            var textToEnccrypt = "Text to enccrypt";
            var message = new Message {Text = textToEnccrypt};
            Assert.NotEqual(textToEnccrypt, message.Text);
            Assert.Equal(textToEnccrypt, message.EncryptedText);
            
        }
    }
}
