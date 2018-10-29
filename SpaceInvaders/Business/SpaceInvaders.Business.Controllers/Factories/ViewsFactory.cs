using System.Collections.Generic;
using SpaceInvaders.Presentation.Views;
using SpaceInvaders.Shared.Base.View;

namespace SpaceInvaders.Business.Controllers.Factories
{
    public static class ViewsFactory
    {
        public static IList<IView> Create(string controllerName)
        {
            switch (controllerName)
            {
                case Contracts.Contracts.HomeController:
                    return GetViewsForHomeController();
                case Contracts.Contracts.GameController:
                    return GetViewsForGameController();
                default:
                    return null;
            }
        }

        private static IList<IView> GetViewsForHomeController()
        {
            var list = new List<IView>
            {
                new HomeView(),
                new MenuView()
            };
            return list;
        }

        private static IList<IView> GetViewsForGameController()
        {
            var list = new List<IView>
            {
                new HomeView(),
                new GameView()
            };
            return list;
        }
    }
}
