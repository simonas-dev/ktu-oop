using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Shared.Base.Factory;

namespace SpaceInvaders.Business.Services.ComputerPlayer
{
    public class StrategyFactory : IFactory<IBoardStrategy, Interfaces.Strategies>
    {
        public IBoardStrategy Create(Interfaces.Strategies param)
        {
            switch (param)
            {
                case Interfaces.Strategies.HardStrategy:
                    return new HardStrategy();
                case Interfaces.Strategies.MediumStrategy:
                   return new MediumStrategy();
                default:
                    return new EasyStrategy();
            }
        }
    }
}
