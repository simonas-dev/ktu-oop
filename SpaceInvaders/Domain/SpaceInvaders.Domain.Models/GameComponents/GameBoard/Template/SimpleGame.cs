using System.Collections.Generic;
using SpaceInvaders.Business.Contracts;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using System.Text;
using System.Linq;

namespace SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template
{
    public class SimpleGame : DrawTemplateBase
    {
        public override string DrawSpaceship(SpaceShip spaceShip)
        {
            FileLogger.Log("Simple Template method pattern: drawing spaceship");

            var builder = new StringBuilder();

            for (var position = 0; position < Contracts.GameSizeWidth; position++)
            {
                var contains = spaceShip.Position.From.X < position && position <= spaceShip.Position.To.X;
                builder.Append(contains ? "_" : " ");
            }

            return builder.ToString();
        }

        public override string DrawEnemiesAndBullets(IEnemyCollection enemies, IList<Bullet> spaceshipBullets)
        {
            FileLogger.Log("Simple Template method pattern: drawing enemies");

            var builder = new StringBuilder();
        
            for (var column = 0; column < Contracts.GameSizeHeight; column++)
            {
                for (var row = 0; row < Contracts.GameSizeWidth; row++)
                {
                    var containsEnemy = enemies.Count(
                        x => x.Position.From.X < row
                        && row <= x.Position.To.X
                        && column == x.Position.From.Y) != 0;

                    var containsBullet = spaceshipBullets.Count(
                        x => x.Position.X == row
                        && x.Position.Y == column) != 0;

                    if (containsEnemy)
                    {
                        builder.Append("\u2302");
                    }
                    else if (containsBullet)
                    {
                        builder.Append("|");
                    }
                    else
                    {
                        builder.Append(" ");
                    }
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        protected string DrawBullets(IList<Bullet> spaceshipBullets)
        {
            var builder = new StringBuilder();

            for (var column = 0; column < Contracts.GameSizeHeight; column++)
            {
                for (var row = 0; row < Contracts.GameSizeWidth; row++)
                {
                    var contains = spaceshipBullets.Count(x => x.Position.X == row && x.Position.Y == column) != 0;
                    builder.AppendLine(contains ? "|" : " ");
                }
            }

            return builder.ToString();
        }
    }
}