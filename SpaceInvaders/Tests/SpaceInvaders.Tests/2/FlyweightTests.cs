using SpaceInvaders.Domain.Models.Flyweight;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class FlyweightTests
    {
        [Fact]
        public void ItBuilds_StartedFlyweight()
        {
            var flyweightFactory = new FlyweightFactory();

            var startedFlyweight = flyweightFactory.GetState(GameStates.Started);

            var startedFlyweight2 = flyweightFactory.GetState(GameStates.Started);

            Assert.NotNull(startedFlyweight);
            Assert.NotNull(startedFlyweight2);
            Assert.Equal(startedFlyweight, startedFlyweight2);
        }

        [Fact]
        public void ItBuilds_CreatedFlyweight()
        {
            var flyweightFactory = new FlyweightFactory();

            var flyweight = flyweightFactory.GetState(GameStates.Created);

            var flyweight2 = flyweightFactory.GetState(GameStates.Created);

            Assert.NotNull(flyweight);
            Assert.NotNull(flyweight2);
            Assert.Equal(flyweight, flyweight2);
        }

        [Fact]
        public void ItBuilds_Flyweight()
        {
            var flyweightFactory = new FlyweightFactory();

            var flyweight = flyweightFactory.GetState(GameStates.Ended);

            var flyweight2 = flyweightFactory.GetState(GameStates.Ended);

            Assert.NotNull(flyweight);
            Assert.NotNull(flyweight2);
            Assert.Equal(flyweight, flyweight2);
        }
    }
}