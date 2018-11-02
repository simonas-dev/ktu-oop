using System;
namespace SpaceInvaders.Domain.Models.GameComponents.Enemies
{
    public class MediumEnemyFactory : EnemyFactory
    {
        public Enemy createEnemy()
        {
            return new MediumEnemy();
        }
    }
}
