using SpaceInvaders.Shared.Base.Controller;
using SpaceInvaders.Shared.Base.View;

namespace SpaceInvaders.Shared.Base.Window
{
    public interface IWindowFascade
    {
        void ChangeController(IController controller);
        void ChangeView(IView view);
        void Run();
        IView View { get; }
    }
}
