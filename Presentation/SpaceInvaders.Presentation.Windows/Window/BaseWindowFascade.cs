using SpaceInvaders.Business.Commands.Game;
using SpaceInvaders.Business.Commands.Home;
using SpaceInvaders.Business.Controllers;
using SpaceInvaders.Business.Controllers.Factories;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Base.Command;
using SpaceInvaders.Shared.Base.Controller;
using SpaceInvaders.Shared.Base.View;
using SpaceInvaders.Shared.Base.Window;
using SpaceInvaders.Shared.Repository;
using SpaceInvaders.Shared.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceInvaders.Presentation.Windows.Window
{
    public class BaseWindowFascade : IWindowFascade
    {
        public IView View { get; private set; }
        private IController _controller;
        private Command _initializeGameCommand;
        private Command _showProfilesCommand;

        public BaseWindowFascade()
        {
            try {
                Console.SetWindowSize(160, 40);
            } catch {}
            Console.CursorVisible = false;
        }

        public void Run()
        {
            Mediator mediator = InstantiateMediator();
            Console.WriteLine("Facade works");
            Thread.Sleep(1000);

            _controller = new HomeController(ViewsFactory.Create("HomeController"), this, new PlayerRepository(), mediator);
            _showProfilesCommand = new ShowPlayerProfilesCommand((IHomeController)_controller);
            _showProfilesCommand.Execute();

            while (true)
            {
                Render();
                HandleInput();
            }
        }

        private static Mediator InstantiateMediator()
        {
            var mediator = new Mediator();
            mediator.Register<IHandleQueries<IQuery<List<Player>>, List<Player>>>(delegate
            {
                return new PlayerListQueryHandler();
            });
            mediator.Register<IHandleQueries<IQuery<Player>, Player>>(delegate
            {
                return new PlayerQueryHandler();
            });

            mediator.Register<IHandleQueries<IQuery<List<Player>>, List<Player>>, PlayerListQueryHandler>();
            mediator.Register<IHandleQueries<IQuery<Player>, Player>, PlayerQueryHandler>();
            return mediator;
        }

        private void HandleInput()
        {
            View.HandleInput();
        }

        private void Render()
        {
            if (View != null)
            {
                ClearLastLinesInWindow(GetLines(View.GetChangingPart()));
                Console.Write(View.GetChangingPart());
            }
            else
            {
                Console.WriteLine("Loading...");
                ClearLastLinesInWindow();              
            }
        }

        private static int GetLines(string getChangingPart)
        {
            var numLines = getChangingPart.Split('\n').Length;
            return numLines-1;
        }

        public void ChangeView(IView view)
        {
            View = view;
            Console.Clear();
            if (View != null)
            {
                Console.Write(View.GetConstantPart());
            }
        }

        public void ChangeController(IController controller)
        {
            _controller = controller;
            _initializeGameCommand = new InitializeGameCommand((IGameController)controller);
            _initializeGameCommand.Execute();
        }

        private static void ClearLastLinesInWindow(int lines = 1)
        {
            for (var i = 0; i < lines; i++)
            {
                if (Console.CursorTop - 1 <= 0) continue;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

    }
}
