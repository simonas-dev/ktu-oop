using SpaceInvaders.Business.Services.Interfaces;

namespace SpaceInvaders.Business.Services.ComputerPlayer.Strategies
{
    public class MediumStrategy : IBoardStrategy
    {
        public MediumStrategy(string profileName)
        {
            ProfileName = profileName;
        }

        public Interfaces.Strategies Name => Interfaces.Strategies.MediumStrategy;
        public int InitialSize => 7;
        public int EasyEnemyProbability => 0;
        public int MediumEnemyProbability => 30;
        public int HardEnemyProbability => 70;
        public string ProfileName { get; set; }
    }
}