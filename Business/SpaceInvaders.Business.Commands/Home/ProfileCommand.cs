using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Shared.Base.Command;

namespace SpaceInvaders.Business.Commands.Home
{
    public class ProfileCommand : Command
    {
        private readonly IHomeController _controller;

        public ProfileCommand(IHomeController controller)
        {
            _controller = controller;
        }

        public override void Execute(string parameter = null)
        {
            _controller.SelectProfile(parameter);
        }
    }
}