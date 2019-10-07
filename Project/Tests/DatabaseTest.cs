using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class DatabaseTest : GenericTest
    {

        public DatabaseTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void DatabaseConnectionTest()
        {
            //arrange
            var canConnect = false;
            //act
            using (SQLiteContext context = new SQLiteContext())
            {
                canConnect = context.Database.CanConnect();
            }
            //asset
            Assert.True(canConnect);

        }
        [Fact]
        public void DatabaseInMemoryTest()
        {
            //arrange
            DbContextOptions<SQLiteContext> options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            //act
            using (var context = new SQLiteContext(options))
            {
                context.Users.Add(new User());


                context.SaveChanges();
            }

            //asset

        }


    }

}
