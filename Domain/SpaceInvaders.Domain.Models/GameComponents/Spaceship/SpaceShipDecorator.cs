using System.Collections.Generic;
using SpaceInvaders.Domain.Models.GameComponents.Base;

namespace SpaceInvaders.Domain.Models.GameComponents.Spaceship
{
    public abstract class SpaceShipDecorator : ISpaceShip
    {
        private readonly SpaceShip _decoratedSpaceShip;

        public IList<Bullet> Bullets { get; set; }

        public Block Position { get; set; }

        public int BaseDamage { get; }

        public SpaceShipDecorator(SpaceShip spaceShip)
        {
            Bullets = spaceShip.Bullets;
            Position = spaceShip.Position;
            _decoratedSpaceShip = spaceShip;
            BaseDamage = spaceShip.BaseDamage;
        }

        public virtual void Shoot()
        {
            _decoratedSpaceShip.Shoot();
        }

        public void RefreshBullets()
        {
            _decoratedSpaceShip.RefreshBullets();
        }
    }
}