using SpaceInvaders.Domain.Models.GameComponents.Base;
using System.Collections.Generic;

namespace SpaceInvaders.Domain.Models.GameComponents.Spaceship
{
    public class SpaceShip : ISpaceShip
    {
        public IList<Bullet> Bullets { get; set; }

        public Block Position { get; set; }

        public int BaseDamage { get; }

        public SpaceShip()
        {
            Bullets = new List<Bullet>();
            BaseDamage = 1;
        }

        public void Shoot()
        {
            var position = new Position((Position.From.X + Position.To.X)/2, Position.From.Y-9);

            Bullets.Add(new Bullet(position));
        }

        public void RefreshBullets()
        {
            foreach (var bullet in Bullets)
            {
                bullet.Position.MoveUp();
                if (bullet.Position.Y > 31)
                {
                    Bullets.Remove(bullet);
                }
            }
        }
    }
}