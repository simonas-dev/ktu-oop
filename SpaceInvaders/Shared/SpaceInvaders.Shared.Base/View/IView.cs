using SpaceInvaders.Shared.Base.Controller;

namespace SpaceInvaders.Shared.Base.View
{
    public interface IView
    {
        string GetConstantPart();
        string GetChangingPart();
        void HandleInput();
        void InsertData(object obj);
        void AddController(IController controller);

        string Name { get; }

    }
}