using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Domain;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class UnitTest1 : GenericTest
    {

        public UnitTest1(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Test1()
        {
            var user1 = new User()
            {
                Id = System.Guid.NewGuid(),
                Username = "user1"
            };
            var user2 = new User()
            {
                Id = System.Guid.NewGuid(),
                Username = "user2"
            };
            var user3 = new User()
            {
                Id = System.Guid.NewGuid(),
                Username = "user3"
            };
            var user4 = new User()
            {
                Id = System.Guid.NewGuid(),
                Username = "user4"
            };

            var conversationsList = new List<Conversation>();

            var conversation1 = new Conversation()
            {
                Id = System.Guid.NewGuid(),
                User = new List<User>()
            };
            conversation1.User.Add(user1);
            conversation1.User.Add(user2);


            var conversation2 = new Conversation()
            {
                Id = System.Guid.NewGuid(),
                User = new List<User>()
            };
            conversation2.User.Add(user1);
            conversation2.User.Add(user3);


            var conversation3 = new Conversation()
            {
                Id = System.Guid.NewGuid(),
                User = new List<User>()
            };
            conversation3.User.Add(user2);
            conversation3.User.Add(user3);

            this.Output.WriteLine(conversation1.Id.ToString());
            this.Output.WriteLine(conversation2.Id.ToString());
            this.Output.WriteLine(conversation3.Id.ToString());

            conversationsList.Add(conversation1);
            conversationsList.Add(conversation2);
            conversationsList.Add(conversation3);


            var c = new List<User> { user4, user3 };



            //var q = conversationsList.Where(x => x.User.Any(user => user.Id == user3.Id));
            var q = conversationsList.Where(x => x.User.Any(user => user.Id == user3.Id) && x.User.Any(user => user.Id == user2.Id));



            var conversations = q.ToList();
            for (int i = 0; i < conversations.Count; i++)
            {

                this.Output.WriteLine(conversations[i].Id.ToString());
                this.Output.WriteLine(conversations[i].User.ToArray()[0].Username.ToString());
                this.Output.WriteLine(conversations[i].User.ToArray()[1].Username.ToString());


            }
      
        }

      
    }
}
