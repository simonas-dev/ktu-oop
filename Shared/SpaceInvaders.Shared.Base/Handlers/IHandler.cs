namespace SpaceInvaders.Shared.Base.Handlers
{
    public interface IHandler
    {
        IHandler Successor { get; }

        void SetSuccessor(IHandler successor);

        void HandleRequest(string request);
    }
}