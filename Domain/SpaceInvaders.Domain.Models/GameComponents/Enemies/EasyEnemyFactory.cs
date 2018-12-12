using System;
namespace SpaceInvaders.Domain.Models.GameComponents.Enemies
{
    public class EasyEnemyFactory : EnemyFactory
    {
        public Enemy createEnemy()
        {
            return new EasyEnemy();
        }
    }
}
