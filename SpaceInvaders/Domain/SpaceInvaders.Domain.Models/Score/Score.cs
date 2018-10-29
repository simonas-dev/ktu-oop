using System;

namespace SpaceInvaders.Domain.Models.Score
{
    public abstract class Score
    {
        public DateTime Date { get; set; }
        public int Number { get; set; }

        protected Score()
        {
            Date = DateTime.Now;
            Number = 0;
        }

        public abstract void IncreaseScore(int number);

        public abstract void UpdateDate(DateTime date);
    }
}