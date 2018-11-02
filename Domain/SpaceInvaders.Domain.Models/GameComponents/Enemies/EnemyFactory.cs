using System;
namespace SpaceInvaders.Domain.Models.GameComponents.Enemies
{
    public interface EnemyFactory
    {
        Enemy createEnemy();
    }
}
