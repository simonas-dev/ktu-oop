using SpaceInvaders.Domain.Models.GameComponents.Base;

namespace SpaceInvaders.Domain.Models.GameComponents
{
    public class Bullet
    {
        public Position Position { get; set; }

        public Bullet(Position position)
        {
            Position = position;
        }
    }
}