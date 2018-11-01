using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.Enemies;
using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using SpaceInvaders.Domain.Models.Score;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class ObserverTests
    {
        [Fact]
        public void ItHasSetAmountOfEnemies_OnTheGameBoardSubscribe()
        {
            // Prepare:
            var score = new RealScore();

            var visitor = new EnemyEasyVisitor(score);

            var spaceship = new SpaceShip();

            var gameTemplate = new SimpleGame();

            var board = new GameBoard(spaceship, visitor, gameTemplate);

            var enemiesList = new List<Enemy>();

            // Act:

            var enemy = new EasyEnemy();

            enemiesList.Add(enemy);
            enemiesList.Add(enemy.Clone());
            enemiesList.Add(enemy.Clone());

            enemiesList.ForEach(e => board.EnemiesSubscribe(e));

            // Assert:

            Assert.NotNull(board);
            Assert.Equal(board.EnemiesCount, enemiesList.Count);
        }

        [Fact]
        public void ItHasSetAmountOfEnemies_OnTheGameBoardUnsubscribe()
        {
            // Prepare:

            var score = new RealScore();

            var visitor = new EnemyEasyVisitor(score);

            var spaceship = new SpaceShip();

            var gameTemplate = new SimpleGame();

            var board = new GameBoard(spaceship, visitor, gameTemplate);

            var enemiesList = new List<Enemy>();

            // Act:

            var enemy = new EasyEnemy();

            enemiesList.Add(enemy);
            enemiesList.Add(enemy.Clone());
            enemiesList.Add(enemy.Clone());

            enemiesList.ForEach(e => board.EnemiesSubscribe(e));

            board.EnemyUnsubscribe(enemiesList.FirstOrDefault());

            // Assert:

            Assert.NotNull(board);
            Assert.Equal(board.EnemiesCount, enemiesList.Count - 1);
        }

        [Fact]
        public void ItNotifiesSubscribers_OnTheGameBoardRefreshView()
        {
            // Prepare:

            var score = new RealScore();

            var visitor = new EnemyEasyVisitor(score);

            var spaceship = new SpaceShip { Position = new Block {From = new Position(1, 1), To = new Position(1, 1)} };

            var gameTemplate = new SimpleGame();

            var board = new GameBoard(spaceship, visitor, gameTemplate);

            // Act:

            var enemy = new EasyEnemy
            {
                Position = new Block()
                {
                    From = new Position(1, 1),
                    To = new Position(1, 1)
                }
            };


            board.EnemiesSubscribe(enemy);

            spaceship.Shoot();

            board.RefreshView();

            // Assert:

            Assert.Equal(enemy.Health, 1);
        }

        [Fact]
        public void EnemyUnsubcribesIfDies_OnTheGameBoardRefreshView()
        {
            // Prepare:

            var score = new RealScore();

            var visitor = new EnemyEasyVisitor(score);

            var spaceship = new SpaceShip { Position = new Block { From = new Position(1, 1), To = new Position(1, 1) } };

            var gameTemplate = new SimpleGame();

            var board = new GameBoard(spaceship, visitor, gameTemplate);

            // Act:

            var enemy = new EasyEnemy
            {
                Position = new Block()
                {
                    From = new Position(1, 1),
                    To = new Position(1, 1)
                }
            };


            board.EnemiesSubscribe(enemy);
            spaceship.Shoot();

            board.RefreshView();

            // Assert:

            Assert.Equal(board.EnemiesCount, 1);
        }
    }
}