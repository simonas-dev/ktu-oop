using System;

namespace SpaceInvaders.Domain.Models.Score
{
    public class RealScore : Score
    {
        public override void IncreaseScore(int number)
        {
            Number += number;
        }

        public override void UpdateDate(DateTime date)
        {
            Date = date;
        }
    }
}