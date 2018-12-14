namespace SpaceInvaders.Business.Services.Interfaces
{
    public interface IBoardStrategy
    {
        Strategies Name { get; }
        int InitialSize { get; }
        int EasyEnemyProbability { get; }
        int MediumEnemyProbability { get; }
        int HardEnemyProbability { get; }
        string ProfileName { get; set; }
    }
}
