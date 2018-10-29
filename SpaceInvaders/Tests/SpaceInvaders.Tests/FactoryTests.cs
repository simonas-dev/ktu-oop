using SpaceInvaders.Business.Services.ComputerPlayer;
using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Business.Services.Interfaces;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void ItCreates_EasyStrategy()
        {
            // Prepare :

            var factory = new StrategyFactory();

            // Act:

            var strategy = factory.Create(Strategies.EasyStrategy);

            // Assert:

            Assert.NotNull(strategy);
            Assert.IsType<EasyStrategy>(strategy);        
        }

        [Fact]
        public void ItCreates_MediumStrategy()
        {
            // Prepare :

            var factory = new StrategyFactory();

            // Act:

            var strategy = factory.Create(Strategies.MediumStrategy);

            // Assert:

            Assert.NotNull(strategy);
            Assert.IsType<MediumStrategy>(strategy);
        }


        [Fact]
        public void ItCreates_HardStrategy()
        {
            // Prepare :

            var factory = new StrategyFactory();

            // Act:

            var strategy = factory.Create(Strategies.HardStrategy);

            // Assert:

            Assert.NotNull(strategy);
            Assert.IsType<HardStrategy>(strategy);
        }
    }
}