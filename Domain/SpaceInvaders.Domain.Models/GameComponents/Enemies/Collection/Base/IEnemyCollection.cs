using System;

namespace SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base
{
    public interface IEnemyCollection
    {
        IIterator CreateIterator();

        int Count();
        int Count(Func<Enemy, bool> predicate);

        Enemy this[int index] { get; set; }
        int GetIndex(Enemy enemy);
    }
}