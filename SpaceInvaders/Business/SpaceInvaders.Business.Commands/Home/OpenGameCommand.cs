using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Shared.Base.Command;

namespace SpaceInvaders.Business.Commands.Home
{
    public class OpenGameCommand : Command
    {
        private readonly IHomeController _controller;

        public OpenGameCommand(IHomeController controller)
        {
            _controller = controller;
        }

        public override void Execute(string parameter = null)
        {
            _controller.ShowGame(parameter);
        }
    }
}