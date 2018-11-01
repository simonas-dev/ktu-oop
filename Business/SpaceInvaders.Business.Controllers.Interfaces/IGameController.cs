using SpaceInvaders.Shared.Base.Handlers;

namespace SpaceInvaders.Business.Controllers.Interfaces
{
    public interface IGameController : IHandler
    {
        void RefreshGame();
        void InitializeGame();
        void MovePlayer(string keyPressed);
        void Shoot();
    }
}