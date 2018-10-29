namespace SpaceInvaders.Shared.Base.Command
{
    public abstract class Command
    {
        public abstract void Execute(string parameter = null);
    }
}