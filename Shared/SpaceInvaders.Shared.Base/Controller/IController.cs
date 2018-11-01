using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Shared.Base.Window;

namespace SpaceInvaders.Shared.Base.Controller
{
    public interface IController
    {
        void ChangeView(string type, object data = null);
        IController ChangeController(string command, IBoardStrategy strategy = null);
        IWindowFascade WindowFacade { get; }
    }
}