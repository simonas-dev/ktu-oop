namespace SpaceInvaders.Domain.Models.GameComponents.Base
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveLeft()
        {
            if (X - 1 <= 0)
            {
                X = 0;
                Y = 10;
            }
            else
            {
                X -= 1;
                Y = X + 10;
            }
        }

        public void MoveRight()
        {
            if (Y + 1 >= 120)
            {
                Y = 120;
                X = 110;
            }
            else
            {
                Y += 1;
                X = Y - 10;
            }
        }

        public void MoveUp()
        {
            Y--;
        }
    }
}