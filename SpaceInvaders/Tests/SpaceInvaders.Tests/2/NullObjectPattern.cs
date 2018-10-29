using SpaceInvaders.Domain.Models.Score;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class NullObjectPattern
    {
        [Fact]
        public void ItCreatesNullObjectCorrectly()
        {
            Score score = new NullScore();

            Assert.IsType<NullScore>(score);

            score.IncreaseScore(3);

            Assert.Equal(0, score.Number);

            score = new RealScore();

            score.IncreaseScore(3);

            Assert.Equal(3, score.Number);
        }
    }
}