using SpaceInvaders.Domain.Models.GameComponents.Enemies;

namespace SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor
{
    public abstract class EnemyVisitorBase
    {
        public Score.Score Score;

        public EnemyVisitorBase(Score.Score score)
        {
            Score = score;
        }

        public abstract void AddScore(EasyEnemy enemy);

        public abstract void AddScore(MediumEnemy enemy);

        public abstract void AddScore(HardEnemy enemy);
    }
}