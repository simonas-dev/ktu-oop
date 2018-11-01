using System;

namespace SpaceInvaders.Domain.Models.States
{
    public class GameStartedState : IGamesState
    {
        public void DoAction(Game games)
        {
            FileLogger.Log("State pattern: started state action");

            Console.WriteLine("Game is running");
            games.SetState(this);
        }
    }
}