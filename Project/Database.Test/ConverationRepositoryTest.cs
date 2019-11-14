using System.Linq;
using Domain;
using Xunit;
using Xunit.Abstractions;

namespace Database.Test
{
    public class ConverationRepositoryTest: OutputTest
    {
        public ConverationRepositoryTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGetUserConversationId()
        {
            var sqLiteContext = new SQLiteContext();
            using var unitOfWork = new UnitOfWork(sqLiteContext);

            var conversation = unitOfWork.ConversationRepository.GetConversation(3,2);
            Output.WriteLine(conversation.ToString());
        }
        [Fact]
        public void TestGetMessagesByConversationId()
        {
            var sqLiteContext = new SQLiteContext();
            using var unitOfWork = new UnitOfWork(sqLiteContext);

            var conversation = unitOfWork.MessageRepository.GetConversationMessages(1);

            foreach (var message in conversation)
            {
                Output.WriteLine(message.Id + " " + message.Text);
                Output.WriteLine("Author:");
                Output.WriteLine(message.Author.Id + " " + message.Author.Username );
                Output.WriteLine("Time:");
                Output.WriteLine(message.Timestamp.ToString());
                Assert.Null(message.Author.Password);
            }
            
            
        }
        
        [Fact]
        public void TestCreatingNewConversation()
        {
            var sqLiteContext = new SQLiteContext();
            IUnitOfWork unitOfWork = new UnitOfWork(sqLiteContext);
            var newConversation = unitOfWork.ConversationRepository.CreateNewConversation(1, 4);
            Output.WriteLine(newConversation.Id.ToString());
        }
        
        
        [Fact]
        public void TestConversationUsers()
        {
            var sqLiteContext = new SQLiteContext();
            IUnitOfWork unitOfWork = new UnitOfWork(sqLiteContext);
            var newConversation = unitOfWork.ConversationRepository.GetConversationUsers(1);
            foreach (var i in newConversation)
            {
                Output.WriteLine(i.ToString());
            }
            
        }
        
    }
}