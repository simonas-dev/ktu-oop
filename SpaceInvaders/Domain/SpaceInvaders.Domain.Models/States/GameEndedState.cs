using System;

namespace SpaceInvaders.Domain.Models.States
{
    public class GameEndedState : IGamesState
    {
        public void DoAction(Game games)
        {
            FileLogger.Log("State pattern: ended state action");

            Console.WriteLine("Game over");
            games.SetState(this);
            Console.Clear();
            Console.WriteLine($"Level ended. Your score is: {games.Score.Number}");
            Console.Read();
            Environment.Exit(0);
        }
    }
}