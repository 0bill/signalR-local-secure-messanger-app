using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Database.Test
{
    public class ContextTest
    {
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
    }
}
