using System;
namespace SpaceInvaders.Domain.Models.GameComponents.Enemies
{
    public class HardEnemyFactory : EnemyFactory
    {
        public Enemy createEnemy()
        {
            return new HardEnemy();
        }
    }
}
