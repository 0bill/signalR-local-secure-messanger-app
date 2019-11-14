using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Database.Test
{
    public class TestMessages: OutputTest
    {
        public TestMessages(ITestOutputHelper output) : base(output)
        {
        }

        private readonly DbContextOptions<SQLiteContext> _dbOptions = new DbContextOptionsBuilder<SQLiteContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;
        
        [SkippableFact]
        public void TestAddingNewMessage()
        {
            
            var sqLiteContext = new SQLiteContext();
            using var unitOfWork = new UnitOfWork(sqLiteContext);
            
            var message = new Message
            {
                AuthorId = 1,
                ConversationId = 1
            }; 
            message.EncryptText("BLABLABLA");
            
            unitOfWork.MessageRepository.AddNewMessage(message);
            sqLiteContext.SaveChanges();
        }

        [Fact]
        public void TestMessageDate()
        {
            var sqLiteContext = new SQLiteContext();
            var q = sqLiteContext.Messages.SingleOrDefault();
            var time = q.Timestamp;
            Output.WriteLine(time.ToString());
        }

        
        [Fact]
        public void TestReceivedMSG()
        {
       
            
            var sqLiteContext = new SQLiteContext();
            using var unitOfWork = new UnitOfWork(sqLiteContext);

            var userId = 2;
            var msgs = new List<Message>();
            msgs.Add(sqLiteContext.Messages.Find(9));
            unitOfWork.MessageRepository.MarkMessagesAsReceived(userId, msgs);
            
        }

    }
}