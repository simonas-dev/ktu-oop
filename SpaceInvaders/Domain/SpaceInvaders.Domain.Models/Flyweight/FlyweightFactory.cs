using SpaceInvaders.Domain.Models.States;
using System.Collections;

namespace SpaceInvaders.Domain.Models.Flyweight
{
    public class FlyweightFactory : IFlyweightFactory
    {
        private Hashtable _flyweights = new Hashtable();

        public FlyweightFactory()
        {
            FileLogger.Log("Flyweight pattern: flyweight factory created");

            _flyweights.Add(GameStates.Created, new GameCreatedState());
            _flyweights.Add(GameStates.Started, new GameStartedState());
            _flyweights.Add(GameStates.Ended, new GameEndedState());
        }

        public IGamesState GetState(GameStates gameStateKey)
        {
            FileLogger.Log($"Flyweight pattern: get {gameStateKey}");

            return (IGamesState)_flyweights[gameStateKey];
        }
    }
}