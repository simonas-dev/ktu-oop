using System;
using System.Text;
using SpaceInvaders.Business.Commands.Game;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.Interfaces;
using SpaceInvaders.Shared.Base.Command;
using SpaceInvaders.Shared.Base.Controller;
using SpaceInvaders.Shared.Base.Handlers;

namespace SpaceInvaders.Presentation.Views
{
    public class GameView : AbstractHandler, IGameView
    {
        private Game _game;

        private Command _refreshGameCommand;

        private Command _movePlayerCommand;

        private Command _shootCommand;

        public string Name => "GameView";

        public void InsertData(object obj)
        {
            _game = (Game) obj;
        }

        public string GetConstantPart()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Currently you are in level {_game.Level}");
            return builder.ToString();
        }

        public string GetChangingPart()
        {
            return Game.Instance.ToString();
        }

        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        _movePlayerCommand.Execute(key.ToString());
                        break;
                    case ConsoleKey.Spacebar:
                        _shootCommand.Execute();
                        break;
                    case ConsoleKey.E:
                        HandleRequest("e");
                        break;
                    case ConsoleKey.P:
                        HandleRequest("p");
                        break;
                }
            }

            _refreshGameCommand.Execute();
        }

        public void AddController(IController controller)
        {
            _refreshGameCommand = new RefreshGameCommand((IGameController) controller);   
            _movePlayerCommand = new MovePlayerCommand((IGameController)controller);
            _shootCommand = new ShootCommand((IGameController) controller);
            this.SetSuccessor((IGameController)controller);
        }

        public override void HandleRequest(string request)
        {
            FileLogger.Log("Chain of responsibility: handle request action");

            if (request == "e")
            {
                Successor.HandleRequest(request);
            } else if (request == "p")
            {
                Console.WriteLine("Pause");
                Console.ReadKey();
            }
        }
    }
}