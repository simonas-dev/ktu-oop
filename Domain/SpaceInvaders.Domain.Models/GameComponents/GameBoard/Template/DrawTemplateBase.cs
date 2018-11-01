using System.Collections.Generic;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using System.Text;

namespace SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template
{
    public abstract class DrawTemplateBase
    {
        public abstract string DrawSpaceship(SpaceShip spaceShip);
        public abstract string DrawEnemiesAndBullets(IEnemyCollection enemies, IList<Bullet> spaceshipBullets);

        public string DrawGameObjects(IEnemyCollection enemies, SpaceShip spaceship)
        {
            FileLogger.Log("Base Template mehtod pattern: drawing all objects");

            var builder = new StringBuilder();
            builder.Append(DrawEnemiesAndBullets(enemies, spaceship.Bullets));
            builder.Append(DrawSpaceship(spaceship));
            return builder.ToString();
        }
    }
}