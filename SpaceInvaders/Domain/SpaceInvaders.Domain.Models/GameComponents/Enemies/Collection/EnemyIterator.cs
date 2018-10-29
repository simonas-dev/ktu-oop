using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;

namespace SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection
{
    public class EnemyIterator : IIterator
    {
        private readonly IEnemyCollection _collection;
        private int _current;

        public EnemyIterator(IEnemyCollection collection)
        {
            FileLogger.Log("Concrete Iterator: created");

            _collection = collection;
        }

        public Enemy First()
        {
            FileLogger.Log("Concrete Iterator: first");

            _current = 0;
            return _collection[_current];
        }

        public Enemy Next()
        {
            FileLogger.Log("Concrete Iterator: next");

            _current++;
            return !Done() ? _collection[_current] : null;
        }

        public bool Done()
        {
            FileLogger.Log("Concrete Iterator: done");

            return _current >= _collection.Count();
        }

        public Enemy CurrentEnemy()
        {
            return _collection[_current];
        }
    }
}