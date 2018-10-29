using System.Collections.Generic;
using SpaceInvaders.Domain.Models.GameComponents.Base;

namespace SpaceInvaders.Domain.Models.GameComponents.Spaceship
{
    public interface ISpaceShip
    {
        IList<Bullet> Bullets { get; set; }

        Block Position { get; set; }

        int BaseDamage { get; }

        void Shoot();

        void RefreshBullets();
    }
}