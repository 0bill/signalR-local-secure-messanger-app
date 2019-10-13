using Xunit;

namespace Database.Test
{
    public class UnitTest1
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
