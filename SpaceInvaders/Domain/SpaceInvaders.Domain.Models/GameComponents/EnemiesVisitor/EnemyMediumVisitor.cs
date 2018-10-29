using SpaceInvaders.Domain.Models.GameComponents.Enemies;

namespace SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor
{
    public class EnemyMediumVisitor : EnemyVisitorBase
    {
        public EnemyMediumVisitor(Score.Score score) : base(score)
        {
            FileLogger.Log("Medium Visitor pattern: created");
        }

        public override void AddScore(EasyEnemy enemy)
        {
            FileLogger.Log("Medium Visitor pattern: add easy enemy score");

            Score.IncreaseScore(2);
        }

        public override void AddScore(MediumEnemy enemy)
        {
            FileLogger.Log("Medium Visitor pattern: add medium enemy score");

            Score.IncreaseScore(4);
        }

        public override void AddScore(HardEnemy enemy)
        {
            FileLogger.Log("Medium Visitor pattern: add hard enemy score");

            Score.IncreaseScore(6);
        }
    }
}