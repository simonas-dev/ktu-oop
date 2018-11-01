using System;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Domain.Models.Memento;
using SpaceInvaders.Domain.Models.Score;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class MementoTests
    {
        [Fact]
        public void ItRestoresDataCorrectly()
        {
            var game = Game.Instance;

            game.Score = new RealScore
            {
                Number = 100,
                Date = DateTime.Today
            };

            GameCaretaker caretaker = new GameCaretaker();

            Assert.NotNull(game.Score);

            Assert.Equal(game.Score.Number, 100);

            caretaker.Memento = game.CreateMemento();

            game.Score.Number = 200;

            Assert.Equal(game.Score.Number, 200);

            game.SetMemento(caretaker.Memento);

            Assert.Equal(game.Score.Number, 100);
        }
    }
}