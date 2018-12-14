using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Shared.Base.Factory;

namespace SpaceInvaders.Business.Services.ComputerPlayer
{
    public class StrategyFactory : IFactory<IBoardStrategy, Interfaces.Strategies>
    {
        public IBoardStrategy Create(Interfaces.Strategies param, string name)
        {
            switch (param)
            {
                case Interfaces.Strategies.HardStrategy:
                    return new HardStrategy(name);
                case Interfaces.Strategies.MediumStrategy:
                   return new MediumStrategy(name);
                default:
                    return new EasyStrategy(name);
            }
        }
    }
}
