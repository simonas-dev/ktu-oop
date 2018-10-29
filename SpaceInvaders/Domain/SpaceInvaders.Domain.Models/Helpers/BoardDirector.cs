using SpaceInvaders.Business.Contracts;
using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template;
using System;
using System.Collections;
using System.Collections.Generic;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;

namespace SpaceInvaders.Domain.Models.Helpers
{
    public class BoardDirector
    {
        private readonly IBoardStrategy _strategy;
        private readonly int _level;
        private readonly Score.Score _score;
        private readonly Position _spaceShipPosition;
        private readonly IList<Bullet> _bullets;

        public BoardDirector(IBoardStrategy strategy, int level, Score.Score score, Position spaceShipPosition, IList<Bullet> bullets)
        {
            _strategy = strategy;
            _level = level;
            _score = score;
            _spaceShipPosition = spaceShipPosition;
            _bullets = bullets;
        }

        public void Construct(IBoardBuilder builder)
        {
            var random = new Random();
            var count = 0;

            switch (_strategy.Name)
            {
                case Strategies.EasyStrategy:
                    builder.AddEnemyVisitor(new EnemyEasyVisitor(_score));
                    builder.AddDrawTheme(new SimpleGame());
                    break;
                case Strategies.MediumStrategy:
                    builder.AddEnemyVisitor(new EnemyMediumVisitor(_score));
                    builder.AddDrawTheme(new RetroGame());
                    break;
                case Strategies.HardStrategy:
                    builder.AddEnemyVisitor(new EnemyHardVisitor(_score));
                    builder.AddDrawTheme(new AlienGame());
                    break;
            }

            for (var column = 0; column < Contracts.GameSizeHeight; column++)
            {
                for (var row = 0; row < Contracts.GameSizeWidth; row=row+10)
                {
                    var number = random.Next(0, 100);

                    var position = new Block() {
                        From = new Position(row, column),
                        To = new Position(row + 8, column)
                    };

                    if (number >= _strategy.HardEnemyProbability)
                    {
                        builder.AddHardEnemy(position);
                    }
                    else if (number >= _strategy.MediumEnemyProbability)
                    {
                        builder.AddMediumEnemy(position);
                    }
                    else
                    {
                        builder.AddEasyEnemy(position);
                    }
                    count++;

                    if (count > _strategy.InitialSize + _level)
                    {
                        break;
                    }
                }
                if (count > _strategy.InitialSize + _level)
                {
                    break;
                }
            }

            if (_spaceShipPosition != null)
            {
                builder.AddSpaceShip(4, _spaceShipPosition.X, _spaceShipPosition.Y, _bullets);
            }
            else
            {
                builder.AddSpaceShip(4, 40, 50);
            }
        }
    }
}