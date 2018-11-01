using SpaceInvaders.Domain.Models.States;

namespace SpaceInvaders.Domain.Models.Flyweight
{
    public interface IFlyweightFactory
    {
        IGamesState GetState(GameStates gameStateKey);
    }
}