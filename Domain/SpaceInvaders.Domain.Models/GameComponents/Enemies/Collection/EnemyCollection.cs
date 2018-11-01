using System;
using System.Collections.Generic;
using System.Linq;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;

namespace SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection
{
    public class EnemyCollection : IEnemyCollection
    {
        private readonly IList<Enemy> _items = new List<Enemy>();

        public IIterator CreateIterator()
        {
            return new EnemyIterator(this);
        }

        int IEnemyCollection.Count()
        {
            return _items.Count;
        }

        int IEnemyCollection.Count(Func<Enemy, bool> predicate)
        {
            return _items.Count(predicate);
        }

        public Enemy this[int index]
        {
            get => _items.Count > 0 ? _items[index] : null;
            set
            {
                if (value != null)
                {
                    _items.Add(value);
                }
                else if (index != -1)
                {
                    _items.RemoveAt(index);
                } else {

                }
            }
        }

        public int GetIndex(Enemy enemy)
        {
            return _items.IndexOf(enemy);
        }
    }
}