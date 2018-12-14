using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.Profile.Expressions;
using SpaceInvaders.Presentation.Views.Profile.Expressions.Base;
using System;

namespace SpaceInvaders.Presentation.Views.Profile
{
    public class Client
    {
        private readonly Context _context;

        public Client(Context context)
        {
            _context = context;
        }

        public Player Interpret(string expression)
        {
            FileLogger.Log($"Interpreter pattern: interpreting text: {expression}");

            Expression exp = null;

            var expressionParts = expression.Split(" ");

            if (expressionParts.Length < 3) {
                Console.WriteLine($"CLI Help: select profile ProfileName");
                Console.WriteLine($"CLI Help: create profile ProfileName");
                return null;
            }

            var command = expressionParts[0].ToLower();

            var entityType = expressionParts[1].ToLower();
            var name = expressionParts[2];

            if (command.ToLower() == "select" && entityType == "profile")
            {
                exp = new PlayerProfilesExpression(name);
                return exp.Interpret(_context);
            }

            if (command.ToLower() == "create" && entityType == "profile")
            {
                exp = new AddPlayerProfileExpression(name);
                return exp.Interpret(_context);
            }

            throw new InvalidOperationException();
        }
    }
}