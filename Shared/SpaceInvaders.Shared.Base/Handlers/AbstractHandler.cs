namespace SpaceInvaders.Shared.Base.Handlers
{
    public abstract class AbstractHandler : IHandler
    {
        public IHandler Successor { get; set; }

        public void SetSuccessor(IHandler successor)
        {
            Successor = successor;
        }

        public abstract void HandleRequest(string request);
    }
}