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

            var conversation = unitOfWork.ConversationRepository.getConversation(3,2);
            Output.WriteLine(conversation.ToString());
        }
        [Fact]
        public void TestGetMessagesByConversationId()
        {
            var sqLiteContext = new SQLiteContext();
            using var unitOfWork = new UnitOfWork(sqLiteContext);

            var conversation = unitOfWork.ConversationRepository.getConversationMessages(1);

            foreach (var message in conversation)
            {
                Output.WriteLine(message.Id + " " + message.Text);
                Output.WriteLine("Author:");
                Output.WriteLine(message.Author.Id + " " + message.Author.Username );
                
                Assert.Null(message.Author.Password);
            }
            
            
        }
    }
}