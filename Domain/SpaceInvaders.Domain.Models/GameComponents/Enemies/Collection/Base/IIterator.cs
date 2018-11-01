namespace SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base
{
    public interface IIterator
    {
        Enemy First();
        Enemy Next();
        bool Done();
        Enemy CurrentEnemy();
    }
}