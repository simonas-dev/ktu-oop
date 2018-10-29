using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection;
using SpaceInvaders.Domain.Models.GameComponents.Enemies.Collection.Base;
using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using System.Collections.Generic;

namespace SpaceInvaders.Domain.Models.GameComponents.GameBoard
{
    public class GameBoard // Subject
    {
        private readonly EnemyVisitorBase _visitor;

        private SpaceShip _spaceShip;

        private readonly IEnemyCollection _enemies; // enemies subscribers

        private readonly IIterator _iterator;

        public int EnemiesCount => _enemies.Count();

        private readonly DrawTemplateBase _drawTemplateBase;

        public GameBoard(SpaceShip spaceShip, EnemyVisitorBase visitor, DrawTemplateBase drawTemplateBase)
        {
            _spaceShip = spaceShip;
            _visitor = visitor;
            _drawTemplateBase = drawTemplateBase;
            _enemies = new EnemyCollection();
            _iterator = _enemies.CreateIterator();
        }

        // Adding enemies to the board
        public void EnemiesSubscribe(Enemy enemy)
        {
            _enemies[_enemies.Count()] = enemy;
        }

        // Removing dead enemies from the board
        public void EnemyUnsubscribe(Enemy enemy)
        {
            var indexOfEnemy = _enemies.GetIndex(enemy);

            _enemies[indexOfEnemy] = null;
        }
  
        public void RefreshView()
        {
            var enemiesToDelete = new List<Enemy>();
            _spaceShip.RefreshBullets();

            // Notify all subscribed enemies that shot was fired to update their health if they are 
            // hiy

            foreach (var bullet in _spaceShip.Bullets)
            {
                for (var enemy = _iterator.First(); !_iterator.Done(); enemy = _iterator.Next())
                {
                    enemy.DidBulletHit(bullet.Position);
                    if (enemy.Health == 0)
                    {
                        enemiesToDelete.Add(enemy);
                    }
                }
            }

            enemiesToDelete.ForEach(EnemyUnsubscribe);

            foreach (var enemy in enemiesToDelete)
            {
                enemy.Accept(_visitor);
            }
        }

        public Position GetPosition()
        {
            if (_spaceShip.Position != null)
            {
                return new Position(this._spaceShip.Position.From.X, this._spaceShip.Position.To.X);
            }

            return null;
        }

        public void Shoot()
        {
            this._spaceShip.Shoot();
        }

        public override string ToString()
        {
            return _drawTemplateBase.DrawGameObjects(_enemies, _spaceShip);
        }

        public DrawTemplateBase GetDrawTemplate()
        {
            return _drawTemplateBase;
        }

        public void VisitVisitor()
        {
            for (var enemy = _iterator.First(); !_iterator.Done(); enemy = _iterator.Next())
            {
                enemy.Accept(_visitor);
            }
        }

        public IList<Bullet> GetBullets()
        {
            return _spaceShip.Bullets;
        }

        public void AssignSpaceship(SpaceShip spaceship)
        {
            _spaceShip = spaceship;
        }
    }
}