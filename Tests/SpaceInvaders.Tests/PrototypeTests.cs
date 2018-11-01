using SpaceInvaders.Domain.Models.GameComponents.Enemies;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class PrototypeTests
    {
        [Fact]
        public void ItCreates_ClonableEnemy()
        {
            // Prepare + Act

            var enemy = new EasyEnemy();

            // Assert

            Assert.NotNull(enemy);
        }

        [Fact]
        public void ItClones_AnEnemyFromCreatedOne()
        {
            // Prepare + Act

            var enemy = new EasyEnemy();

            var clone = enemy.Clone();

            // Assert

            Assert.NotNull(clone);
        }

        [Fact]
        public void ItHasDifferentReference_CreatedEnemyFromCloned()
        {
            // Prepare + Act

            var enemy = new EasyEnemy();

            var clone = enemy.Clone();

            // Assert

            Assert.NotEqual(clone, enemy);
        }
    }
}