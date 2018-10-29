using System;

namespace SpaceInvaders.Domain.Models.Memento
{
    public class GameMemento
    {
        public GameMemento(int level, int number, DateTime date)
        {
            FileLogger.Log("Memento pattern: game memento created");

            Level = level;
            Score = number;
            Date = date;
        }

        public int Score { get; private set; }
        public int Level { get; private set; }
        public DateTime Date { get; private set; }
    }
}