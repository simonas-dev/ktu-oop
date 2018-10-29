using System;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.Profile.Expressions.Base;

namespace SpaceInvaders.Presentation.Views.Profile.Expressions
{
    public class AddPlayerProfileExpression : Expression
    {
        private readonly string _name;

        public AddPlayerProfileExpression(string name)
        {
            _name = name;
        }

        public override Player Interpret(Context context)
        {
            var player = context.AddPlayer(new Player() {Name = _name});

            Console.WriteLine($"You have created player: {player.Name}");

            Console.ReadKey();

            return player;
        }
    }
}