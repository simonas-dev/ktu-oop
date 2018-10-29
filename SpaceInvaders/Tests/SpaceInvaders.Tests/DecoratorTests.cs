using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class DecoratorTests
    {
        [Fact]
        public void ItCreates_BaseSpaceship()
        {
            // Prepare + Act

            var spaceShip = new SpaceShip();

            // Assert

            Assert.NotNull(spaceShip);
        }

        [Fact]
        public void ItHasOneBulletAfterShoot_WithBasicSpaceship()
        {
            // Prepare + Act
            var spaceShip = new SpaceShip { Position = new Block { From = new Position(1, 1), To = new Position(1, 1) } };

            spaceShip.Shoot();

            // Assert

            Assert.Equal(spaceShip.Bullets.Count, 1);
        }

        [Fact]
        public void ItHasTwoBulletsAfterShoot_WithUpgradedSpaceship()
        {
            // Prepare + Act

            var spaceShip = new SpaceShip { Position = new Block { From = new Position(1, 1), To = new Position(1, 1) } };

            var upgradedSpaceship = new DoubleShotSpaceShipDecorator(spaceShip);

            upgradedSpaceship.Shoot();

            // Assert

            Assert.Equal(upgradedSpaceship.Bullets.Count, 2);
        }
    }
}