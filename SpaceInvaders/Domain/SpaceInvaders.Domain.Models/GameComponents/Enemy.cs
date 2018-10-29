using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.EnemiesVisitor;

namespace SpaceInvaders.Domain.Models.GameComponents
{
    public abstract class Enemy
    {
        public Block Position { get; set; }
        public int Health { get; set; }

        public bool DidBulletHit(Position bullet) // Update
        {
            if (bullet.X < Position.From.X || bullet.X > Position.To.X) return false;
            if (bullet.Y < Position.From.Y || bullet.Y > Position.To.Y) return false;
            Health--;
            return true;
        }

        public abstract Enemy Clone();

        public abstract void Accept(EnemyVisitorBase visitor);
    }
}