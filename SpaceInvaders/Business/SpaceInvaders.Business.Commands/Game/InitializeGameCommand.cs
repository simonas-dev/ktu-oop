using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Shared.Base.Command;

namespace SpaceInvaders.Business.Commands.Game
{
    public class InitializeGameCommand : Command
    {
        private readonly IGameController _controller;

        public InitializeGameCommand(IGameController controller)
        {
            _controller = controller;
        }

        public override void Execute(string parameter = null)
        {
            _controller.InitializeGame();
        }

    }
}