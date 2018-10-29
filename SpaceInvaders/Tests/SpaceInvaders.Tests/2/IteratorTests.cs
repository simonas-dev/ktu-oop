using SpaceInvaders.Domain.Models.GameComponents.Enemies;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class IteratorTests
    {
        [Fact]
        public void ItIteratesThroughtCollection()
        {
            var collection = new EnemyCollection
            {
                [0] = new EasyEnemy(),
                [1] = new MediumEnemy(),
                [2] = new HardEnemy()
            };

            var iterator = collection.CreateIterator();

            var total = 0;

            for (var enemy = iterator.First(); !iterator.Done(); enemy = iterator.Next())
            {
                total++;
            }

            Assert.IsType<EnemyCollection>(collection);

            Assert.Equal(3, total);
        }
    }
}