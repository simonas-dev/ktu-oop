using System.Collections.Generic;
using SpaceInvaders.Business.Services.ComputerPlayer.Strategies;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.Helpers;
using SpaceInvaders.Domain.Models.Score;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class VisitorTests
    {
        [Fact]
        public void ItVisitsAnd_AddsEasyScore()
        {
            // Prepare:
            var score = new RealScore();
            var boardDirector = new BoardDirector(new EasyStrategy(), 0, score, new Position(0, 0), new List<Bullet>());
            var builder = new BoardBuilder();
            boardDirector.Construct(builder);
            var board = builder.Build();
            board.VisitVisitor();

            var mscore = new RealScore();
            var mboardDirector = new BoardDirector(new MediumStrategy(), 0, mscore, new Position(0, 0), new List<Bullet>());
            var mbuilder = new BoardBuilder();
            mboardDirector.Construct(mbuilder);
            var mboard = mbuilder.Build();
            mboard.VisitVisitor();

            // Assert:

            Assert.True(score.Number < mscore.Number);
        }

        [Fact]
        public void ItVisitsAnd_AddsMediumScore()
        {
            // Prepare:
            var score = new RealScore();
            var boardDirector = new BoardDirector(new EasyStrategy(), 0, score, new Position(0, 0), new List<Bullet>());
            var builder = new BoardBuilder();
            boardDirector.Construct(builder);
            var board = builder.Build();
            board.VisitVisitor();

            var mscore = new RealScore();
            var mboardDirector = new BoardDirector(new HardStrategy(), 0, mscore, new Position(0, 0), new List<Bullet>());
            var mbuilder = new BoardBuilder();
            mboardDirector.Construct(mbuilder);
            var mboard = mbuilder.Build();
            mboard.VisitVisitor();

            // Assert:

            Assert.True(score.Number < mscore.Number);
        }

        [Fact]
        public void ItVisitsAnd_AddsHardScore()
        {
            // Prepare:
            var score = new RealScore();
            var boardDirector = new BoardDirector(new MediumStrategy(), 0, score, new Position(0, 0), new List<Bullet>());
            var builder = new BoardBuilder();
            boardDirector.Construct(builder);
            var board = builder.Build();
            board.VisitVisitor();

            var mscore = new RealScore();
            var mboardDirector = new BoardDirector(new HardStrategy(), 0, mscore, new Position(0, 0), new List<Bullet>());
            var mbuilder = new BoardBuilder();
            mboardDirector.Construct(mbuilder);
            var mboard = mbuilder.Build();
            mboard.VisitVisitor();

            // Assert:

            Assert.True(score.Number < mscore.Number);
        }
    }
}