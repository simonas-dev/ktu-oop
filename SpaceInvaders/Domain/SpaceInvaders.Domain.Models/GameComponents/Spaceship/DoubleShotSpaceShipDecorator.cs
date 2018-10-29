using SpaceInvaders.Domain.Models.GameComponents.Base;

namespace SpaceInvaders.Domain.Models.GameComponents.Spaceship
{
    public class DoubleShotSpaceShipDecorator : SpaceShipDecorator
    {
        public DoubleShotSpaceShipDecorator(SpaceShip spaceShip) : 
            base(spaceShip)
        {
        }

        public override void Shoot()
        {
            base.Shoot();
            base.Bullets.Add(new Bullet(new Position(this.Position.From.X+2, this.Position.From.Y-2)));
        }
    }
}