using SpaceInvaders.Domain.Models;
using SpaceInvaders.Domain.Models.Flyweight;
using SpaceInvaders.Domain.Models.States;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class StateTests
    {
        [Fact]
        void ItSets_StateCreated_WhenGameCreated()
        {
            var flyweights = new FlyweightFactory();
            var game = Game.Instance;

            var state = flyweights.GetState(GameStates.Created);
            state.DoAction(game);

            Assert.IsType<GameCreatedState>(game.GetState());
        }

        [Fact]
        void ItSets_StateStarted_WhenGameStarted()
        {
            var flyweights = new FlyweightFactory();
            var game = Game.Instance;

            var state = flyweights.GetState(GameStates.Started);
            state.DoAction(game);

            Assert.IsType<GameStartedState>(game.GetState());
        }
    }
}