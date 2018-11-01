using SpaceInvaders.Domain.Models;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void ItCreates_GameInstance()
        {
            // Prepare + Act

            var game = Game.Instance;

            // Assert

            Assert.NotNull(game);
        }

        [Fact]
        public void ItCreate_SingleGameInstance()
        {
            // Prepare + Act

            var firstGame = Game.Instance;

            var secondGame = Game.Instance;

            // Assert

            Assert.Equal(firstGame, secondGame);
        }
    }
}