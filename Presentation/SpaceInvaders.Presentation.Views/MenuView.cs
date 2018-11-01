using System;
using System.Text;
using SpaceInvaders.Business.Commands.Game;
using SpaceInvaders.Business.Commands.Home;
using SpaceInvaders.Business.Contracts;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Presentation.Views.CompositeMenu;
using SpaceInvaders.Presentation.Views.CompositeMenu.Base;
using SpaceInvaders.Presentation.Views.Interfaces;
using SpaceInvaders.Shared.Base.Command;
using SpaceInvaders.Shared.Base.Controller;

namespace SpaceInvaders.Presentation.Views
{
    public class MenuView : IMenuView
    {
        public string Name => "MenuView";
        
        private Command _initializeGameCommand;

        private readonly MenuItem _menu = new LevelMenu("Level menu");

        public MenuView()
        {
            _menu.Add(new LevelMenuItem("Easy"));
            _menu.Add(new LevelMenuItem("Medium"));
            _menu.Add(new LevelMenuItem("Hard"));
        }

        public string GetConstantPart()
        {
            return _menu.Display();
        }

        public string GetChangingPart()
        {
            return string.Empty;
        }

        public void HandleInput()
        {
            var strategy = Console.ReadLine();
            if (strategy != null)
            {
                _initializeGameCommand.Execute(strategy);
            }
        }

        public void InsertData(object obj)
        {
           
        }

        public void AddController(IController controller)
        {
            _initializeGameCommand = new OpenGameCommand((IHomeController)controller);
        }      
    }
}