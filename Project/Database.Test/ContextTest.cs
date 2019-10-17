using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Xunit;
using Xunit.Abstractions;

namespace Database.Test
{
    public class ContextTest : OutputTest
    {
        public ContextTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void DatabaseConnectionTest()
        {
            //arrange
            var canConnect = false;
            //act
            using (var context = new SQLiteContext())
            {
                canConnect = context.Database.CanConnect();
            }

            //asset
            Assert.True(canConnect);
        }

        [Fact]
        public void GetUsersFromDatabase()
        {
            var users = new List<User>();

            using (var context = new SQLiteContext())
            {
                users = context.Users.Select(x => x).ToList();
            }

            foreach (var user in users)
            {
                Output.WriteLine(user.ToString());
            }
        }
    }
}