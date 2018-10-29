using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template;

namespace SpaceInvaders.Domain.Models.Helpers
{
    public interface IBoardBuilder
    {
        GameBoard Build();
        void AddEasyEnemy(Block position);
        void AddMediumEnemy(Block position);
        void AddHardEnemy(Block position);
        void AddSpaceShip(int baseDamage, int fromX, int toX, IList<Bullet> bullets = null);
        void AddEnemyVisitor(EnemyVisitorBase visitor);
        void AddDrawTheme(DrawTemplateBase theme);
    }
}