using SpaceInvaders.Domain.Models;
using SpaceInvaders.Domain.Models.Flyweight;
using SpaceInvaders.Shared.DI;
using System;
using System.IO;

namespace SpaceInvaders.Presentation.GUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var diSetup = new DependencyInjectionSetup().GetScope();

            Gui gui = new GuiAdapter();
            gui.InitializeGui();

            // Code to test if game states are changing

            //var flyweights = new FlyweightFactory();

            //var game = Game.Instance;
            //game.GetState().DoAction(game);
            //Console.WriteLine(game.GetState());

            //var startedState = flyweights.GetState(GameStates.Started);
            //startedState.DoAction(game);
            //Console.WriteLine(game.GetState());

            //var endedState = flyweights.GetState(GameStates.Ended);
            //endedState.DoAction(game);
            //Console.WriteLine(game.GetState());
        }
    }
}