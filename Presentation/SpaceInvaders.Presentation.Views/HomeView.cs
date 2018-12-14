using SpaceInvaders.Business.Contracts;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.Interfaces;
using SpaceInvaders.Shared.Base.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Business.Commands.Home;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Presentation.Views.Profile;
using SpaceInvaders.Shared.Base.Command;

namespace SpaceInvaders.Presentation.Views
{
    public class HomeView : IHomeView
    {
        private IList<Player> _players;

        private Command _profileCommand;

        public string Name => "HomeView";

        public void InsertData(object obj)
        {
            _players = (IList<Player>) obj;
        }

        public string GetConstantPart()
        {
            var builder = new StringBuilder();
            if (_players.Count == 0)
            {
                builder.AppendLine("No accounts");
                builder.AppendLine("To create a new account");
            }
            else
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    builder.AppendLine((i + 1) + ". " + _players[i].Name);
                }
            }
            builder.AppendLine("Enter name of profile. Example 'select profile John'");
            return builder.ToString();
        }

        public string GetChangingPart()
        {
            return string.Empty;
        }

        public void HandleInput()
        {
            var sentence = Console.ReadLine();

            _profileCommand.Execute(sentence);
        }

        public void AddController(IController controller)
        {
            _profileCommand = new ProfileCommand((IHomeController) controller);
        }
    }
}