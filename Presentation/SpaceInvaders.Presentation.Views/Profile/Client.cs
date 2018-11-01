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

            if (expressionParts.Length < 3) throw new InvalidOperationException();

            var command = expressionParts[0];
            var entityType = expressionParts[1];
            var name = expressionParts[2];

            if (command == "Select" || command == "select" || command == "SELECT")
            {
                if (entityType == "Profile" || entityType == "profile" || entityType == "PROFILE")
                {
                    exp = new PlayerProfilesExpression(name);
                    return exp.Interpret(_context);
                }
            }

            if (command == "Create" || command == "create" || command == "CREATE")
            {
                if (entityType == "Profile" || entityType == "profile" || entityType == "PROFILE")
                {
                    exp = new AddPlayerProfileExpression(name);
                    return exp.Interpret(_context);
                }
            }

            throw new InvalidOperationException();
        }
    }
}