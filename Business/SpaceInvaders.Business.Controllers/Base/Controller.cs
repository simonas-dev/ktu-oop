using System.Collections.Generic;
using System.Linq;
using SpaceInvaders.Business.Controllers.Factories;
using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Shared.Base.Controller;
using SpaceInvaders.Shared.Base.View;
using SpaceInvaders.Shared.Base.Window;

namespace SpaceInvaders.Business.Controllers.Base
{
    public abstract class Controller : IController
    {
        public readonly Dictionary<string, IView> Views;
        public IWindowFascade WindowFacade { get; }

        protected Controller(IEnumerable<IView> availableViews, IWindowFascade windowFascade)
        {
            Views = new Dictionary<string, IView>();
            WindowFacade = windowFascade;
            foreach (var view in availableViews)
            {
                Views.Add(view.Name, view);
            }
        }

        public void ChangeView(string type, object data = null)
        {
            var view = Views.GetValueOrDefault(type);
            if (data != null)
            {
                view.InsertData(data);
            }
            WindowFacade.ChangeView(view);
        }

        public IController ChangeController(string command, IBoardStrategy strategy = null)
        {
            return command.Equals(Contracts.Contracts.GameController)
                ? new GameController(ViewsFactory.Create(command), WindowFacade, strategy) : this;
        }
        
    }
}