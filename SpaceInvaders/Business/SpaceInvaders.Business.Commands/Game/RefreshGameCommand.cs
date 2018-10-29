using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Shared.Base.Command;

namespace SpaceInvaders.Business.Commands.Game
{
    public class RefreshGameCommand : Command
    {
        private readonly IGameController _controller;

        public RefreshGameCommand(IGameController controller)
        {
            _controller = controller;
        }

        public override void Execute(string parameter = null)
        {
            _controller.RefreshGame();
        }
    }
}