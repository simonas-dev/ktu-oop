using System;

namespace SpaceInvaders.Domain.Models.States
{
    public class GameCreatedState : IGamesState
    {
        public void DoAction(Game games)
        {
            FileLogger.Log("State pattern: created state action");
            Console.WriteLine("New game is created");
            games.SetState(this);
        }
    }
}