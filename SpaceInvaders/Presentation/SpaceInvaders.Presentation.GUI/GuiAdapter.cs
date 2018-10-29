using System;
using SpaceInvaders.Presentation.Windows.Window;

namespace SpaceInvaders.Presentation.GUI
{
    public class GuiAdapter : Gui
    {
        private readonly BaseWindowFascade _windowFascade = new BaseWindowFascade();

        public override void InitializeGui()
        {
            Console.WriteLine("Adapter works");
            Console.ReadKey();
            _windowFascade.Run();
        }
    }
}