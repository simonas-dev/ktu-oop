using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Business.Services.Interfaces;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class StrategyTests
    {
        [Fact]
        public void ItCreates_EasyStrategy()
        {
            // Prepare

            IBoardStrategy strategy = new EasyStrategy();

            // Assert

            Assert.NotNull(strategy);
            Assert.IsType<EasyStrategy>(strategy);
            Assert.True(strategy.EasyEnemyProbability == 0);
            Assert.True(strategy.MediumEnemyProbability == 50);
            Assert.True(strategy.HardEnemyProbability == 80);
        }

        [Fact]
        public void ItCreates_MediumStrategy()
        {
            // Prepare

            IBoardStrategy strategy = new MediumStrategy();

            // Assert

            Assert.NotNull(strategy);
            Assert.IsType<MediumStrategy>(strategy);
            Assert.True(strategy.EasyEnemyProbability == 0);
            Assert.True(strategy.MediumEnemyProbability == 30);
            Assert.True(strategy.HardEnemyProbability == 70);
        }

        [Fact]
        public void ItCreates_HardStrategy()
        {
            // Prepare

            IBoardStrategy strategy = new HardStrategy();

            // Assert

            Assert.NotNull(strategy);
            Assert.IsType<HardStrategy>(strategy);
            Assert.True(strategy.EasyEnemyProbability == 0);
            Assert.True(strategy.MediumEnemyProbability == 30);
            Assert.True(strategy.HardEnemyProbability == 50);
        }
    }
}