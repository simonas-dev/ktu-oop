using System.Collections.Generic;
using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard;
using SpaceInvaders.Domain.Models.Helpers;
using SpaceInvaders.Domain.Models.Score;
using Xunit;

namespace SpaceInvaders.Tests
{
    public class BuilderTests
    {
        [Fact]
        public void ItBuilds_GameBoard()
        {
            // Prepare:
            var score = new RealScore();
            var boardDirector = new BoardDirector(new EasyStrategy(), 0, score, new Position(0, 0), new List<Bullet>());
            var builder = new BoardBuilder();

            // Act:

            boardDirector.Construct(builder);
            var board = builder.Build();

            // Assert:

            Assert.NotNull(board);
            Assert.IsType<GameBoard>(board);
        }
    }
}