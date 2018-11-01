using SpaceInvaders.Business.Services.Interfaces;

namespace SpaceInvaders.Business.Services.ComputerPlayer.Strategies
{
    public class EasyStrategy : IBoardStrategy
    {
        public Interfaces.Strategies Name => Interfaces.Strategies.EasyStrategy;
        public int InitialSize => 5;
        public int EasyEnemyProbability => 0;
        public int MediumEnemyProbability => 50;
        public int HardEnemyProbability => 80;
    }
}
