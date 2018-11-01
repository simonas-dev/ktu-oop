using System.Collections.Generic;
using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.GameComponents.GameBoard.Template;
using SpaceInvaders.Domain.Models.Helpers;
using SpaceInvaders.Domain.Models.Score;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class TemplateMethodTests
    {
        [Fact]
        public void ItBuilds_DifferentTemplatesSimple()
        {
            // Prepare:
            var score = new RealScore();
            var boardDirector = new BoardDirector(new EasyStrategy(), 0, score, new Position(0, 0), new List<Bullet>());
            var builder = new BoardBuilder();

            // Act:

            boardDirector.Construct(builder);
            var board = builder.Build();

            var drawTemplate = board.GetDrawTemplate();

            // Assert:

            Assert.NotNull(drawTemplate);
            Assert.IsType<SimpleGame>(drawTemplate);
        }

        [Fact]
        public void ItBuilds_DifferentTemplatesRetro()
        {
            // Prepare:
            var score = new RealScore();
            var boardDirector = new BoardDirector(new MediumStrategy(), 0, score, new Position(0, 0), new List<Bullet>());
            var builder = new BoardBuilder();

            // Act:

            boardDirector.Construct(builder);
            var board = builder.Build();

            var drawTemplate = board.GetDrawTemplate();

            // Assert:

            Assert.NotNull(drawTemplate);
            Assert.IsType<RetroGame>(drawTemplate);
        }
    }
}