using SpaceInvaders.Domain.Models.GameComponents.Enemies;

namespace SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor
{
    public class EnemyEasyVisitor : EnemyVisitorBase
    {
        public EnemyEasyVisitor(Score.Score score) : base(score)
        {
            FileLogger.Log("Easy Visitor pattern: created");
        }

        public override void AddScore(EasyEnemy enemy)
        {
            FileLogger.Log("Easy Visitor pattern: add easy enemy score");

            Score.IncreaseScore(1);
        }

        public override void AddScore(MediumEnemy enemy)
        {
            FileLogger.Log("Easy Visitor pattern: add medium enemy score");

            Score.IncreaseScore(2);
        }

        public override void AddScore(HardEnemy enemy)
        {
            FileLogger.Log("Easy Visitor pattern: add hard enemy score");

            Score.IncreaseScore(3);
        }
    }
}