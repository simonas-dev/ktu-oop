using SpaceInvaders.Business.Contracts;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.Enemies;
using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template;
using SpaceInvaders.Domain.Models.GameComponents.Spaceship;
using System.Collections.Generic;
using System.Linq;

namespace SpaceInvaders.Domain.Models.Helpers
{
    public class BoardBuilder : IBoardBuilder
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();
        private SpaceShip _spaceShip = new SpaceShip();

        private Enemy EasyEnemy { get; }
        private Enemy MediumEnemy { get; }
        private Enemy HardEnemy { get; }
        private EnemyVisitorBase Visitor { get; set; }
        private DrawTemplateBase Theme { get; set; }
        private GameBoard Board { get; set; }

        public BoardBuilder()
        {
            EasyEnemy = new EasyEnemyFactory().createEnemy();
            MediumEnemy = new MediumEnemyFactory().createEnemy();
            HardEnemy = new HardEnemyFactory().createEnemy();
        }

        public GameBoard Build()
        {
            Board = new GameBoard(_spaceShip, Visitor, Theme);

            foreach (var enemy in _enemies)
            {
                Board.EnemiesSubscribe(enemy);
            }

            return Board;
        }

        public void AddEasyEnemy(Block position)
        {
            var easyEnemy = EasyEnemy.Clone();
            easyEnemy.Position = position;
            _enemies.Add(easyEnemy);
        }

        public void AddMediumEnemy(Block position)
        {
            var mediumEnemy = MediumEnemy.Clone();
            mediumEnemy.Position = position;
            _enemies.Add(mediumEnemy);
        }

        public void AddHardEnemy(Block position)
        {
            var hardEnemy = HardEnemy.Clone();
            hardEnemy.Position = position;
            _enemies.Add(hardEnemy);
        }

        public void AddSpaceShip(int baseDamage, int fromX, int toX, IList<Bullet> bullets = null)
        {
            Board?.RefreshView();

            bullets?.ToList().ForEach(x=>x.Position.MoveUp());

            _spaceShip = new SpaceShip()
            {
                Position = new Block()
                {
                    From = new Position(fromX, Contracts.GameSizeHeight),
                    To = new Position(toX, Contracts.GameSizeHeight)
                },
                Bullets = bullets ?? new List<Bullet>()
            };

            Board?.AssignSpaceship(_spaceShip);
        }

        public void AddEnemyVisitor(EnemyVisitorBase visitor)
        {
            Visitor = visitor;
        }

        public void AddDrawTheme(DrawTemplateBase theme)
        {
            Theme = theme;
        }
    }
}