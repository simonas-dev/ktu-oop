using System;
using System.Collections.Generic;
using System.Linq;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.Profile.Expressions.Base;

namespace SpaceInvaders.Presentation.Views.Profile.Expressions
{
    public class PlayerProfilesExpression : Expression
    {
        private readonly string _name;

        public PlayerProfilesExpression(string name)
        {
            _name = name;
        }

        public override Player Interpret(Context context)
        {
            var player = context
                .GetAllPlayers()
                .SingleOrDefault(x=>x.Name == _name);

            if (player == null)
            {
                var index = int.Parse(_name);
                player = context
                    .GetAllPlayers()[index];
            }

            Console.WriteLine($"You have selected player: {player?.Name}");

            Console.ReadKey();

            return player;
        }
    }
}