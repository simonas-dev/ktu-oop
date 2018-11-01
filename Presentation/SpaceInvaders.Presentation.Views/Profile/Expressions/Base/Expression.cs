using SpaceInvaders.Domain.Models;

namespace SpaceInvaders.Presentation.Views.Profile.Expressions.Base
{
    public abstract class Expression
    {
        public abstract Player Interpret(Context context);
    }
}