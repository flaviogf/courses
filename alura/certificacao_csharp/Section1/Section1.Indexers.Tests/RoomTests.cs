using Xunit;

namespace Section1.Indexers
{
    public class RoomTests
    {
        [Fact]
        public void ShouldAddPersonInRoom()
        {
            var room = new Room();

            room["01"] = "Flavio";

            Assert.Equal("Flavio", room["01"]);
        }
    }
}