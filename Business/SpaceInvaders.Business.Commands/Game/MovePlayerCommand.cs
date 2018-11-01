using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Shared.Base.Command;

namespace SpaceInvaders.Business.Commands.Game
{
    public class MovePlayerCommand : Command
    {
        private readonly IGameController _controller;

        public MovePlayerCommand(IGameController controller)
        {
            _controller = controller;
        }

        public override void Execute(string parameter = null)
        {
            if (parameter != null)
            {
                _controller.MovePlayer(parameter);
            }
        }
    }
}