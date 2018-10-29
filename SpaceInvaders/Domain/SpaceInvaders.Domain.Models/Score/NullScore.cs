using System;

namespace SpaceInvaders.Domain.Models.Score
{
    public class NullScore : Score
    {
        public override void IncreaseScore(int number)
        {
            FileLogger.Log("Null pattern: increase score");
        }

        public override void UpdateDate(DateTime date)
        {
            FileLogger.Log("Null pattern: update date");
        }
    }
}