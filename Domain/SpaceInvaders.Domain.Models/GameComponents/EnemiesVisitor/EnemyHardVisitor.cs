using SpaceInvaders.Domain.Models.GameComponents.Enemies;

namespace SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor
{
    public class EnemyHardVisitor : EnemyVisitorBase
    {
        public EnemyHardVisitor(Score.Score score) : base(score)
        {
            FileLogger.Log("Hard Visitor pattern: created");
        }

        public override void AddScore(EasyEnemy enemy)
        {
            FileLogger.Log("Hard Visitor pattern: add easy enemy score");

            Score.IncreaseScore(3);
        }

        public override void AddScore(MediumEnemy enemy)
        {
            FileLogger.Log("Hard Visitor pattern: add medium enemy score");

            Score.IncreaseScore(6);
        }

        public override void AddScore(HardEnemy enemy)
        {
            FileLogger.Log("Hard Visitor pattern: add hard enemy score");

            Score.IncreaseScore(9);
        }
    }
}