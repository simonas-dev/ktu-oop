using SpaceInvaders.Shared.Base.Controller;

namespace SpaceInvaders.Business.Controllers.Interfaces
{
    public interface IHomeController : IController
    {
        void ShowProfiles();
        void ShowGame(string parameter);
        void SelectProfile(string sentence);
    }
}