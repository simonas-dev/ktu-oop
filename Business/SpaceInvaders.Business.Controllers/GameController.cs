using System;
using SpaceInvaders.Business.Controllers.Base;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Domain.Models.GameComponents;
using SpaceInvaders.Domain.Models.GameComponents.Base;
using SpaceInvaders.Domain.Models.Helpers;
using SpaceInvaders.Domain.Models.Score;
using SpaceInvaders.Domain.Models.States;
using SpaceInvaders.Shared.Base.View;
using SpaceInvaders.Shared.Base.Window;
using System.Collections.Generic;
using SpaceInvaders.Shared.Base.Handlers;
using System.Threading;

namespace SpaceInvaders.Business.Controllers
{
    public class GameController : Controller, IGameController, IHandler
    {
        private readonly IBoardStrategy _strategy;
        private Position _spaceShipPosition;
        private readonly Score _score;
        private BoardBuilder _builder;
        private BoardDirector _boardDirector;

        public GameController(IEnumerable<IView> availableViews, IWindowFascade windowFascade, IBoardStrategy strategy)
            : base(availableViews, windowFascade)
        {
            Game game = Game.Instance;

            _strategy = strategy;
            _score = new RealScore();
            game.Score = _score;
            if (_spaceShipPosition == null)
            {
                _spaceShipPosition = game.Board?.GetPosition();
            }
            var bullets = game.Board?.GetBullets() != null ? game.Board?.GetBullets() : new List<Bullet>();
            _boardDirector = new BoardDirector(_strategy, game.Level, game.Score, _spaceShipPosition, bullets);
            _builder = new BoardBuilder();
            _boardDirector.Construct(_builder);
            game.Board = _builder.Build();
        }

        private Game GetGame()
        {           
            Game game = Game.Instance;
            if (_spaceShipPosition == null)
            {
                _spaceShipPosition = game.Board?.GetPosition();
            }
            var bullets = game.Board?.GetBullets() != null ? game.Board?.GetBullets() : new List<Bullet>();
            _boardDirector = new BoardDirector(_strategy, game.Level, game.Score, _spaceShipPosition, bullets);
            _boardDirector.Construct(_builder);
            if (game.Board?.EnemiesCount == 0)
            {
                var state = new GameEndedState();
                state.DoAction(game);
            }
            return game;
        }

        public void RefreshGame()
        {
            WindowFacade.View.InsertData(GetGame());
        }

        public void MovePlayer(string keyPressed)
        {
            if (keyPressed == "LeftArrow")
                _spaceShipPosition.MoveLeft();
            else if (keyPressed == "RightArrow")
                _spaceShipPosition.MoveRight();
        }

        public void Shoot()
        {
            Game game = Game.Instance;
            game.Board.Shoot();
        }

        public void InitializeGame()
        {
            ChangeView(Contracts.Contracts.GameView, GetGame());
            WindowFacade.View.AddController(this);
        }

        public IHandler Successor { get; private set; }

        public void SetSuccessor(IHandler successor)
        {
            throw new System.NotImplementedException();
        }

        public void HandleRequest(string request)
        {
            FileLogger.Log("Chain of responsibility: handle request action");

            if (request == "e")
            {
                Console.Clear();
                Console.WriteLine("Press any key to exit application");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}