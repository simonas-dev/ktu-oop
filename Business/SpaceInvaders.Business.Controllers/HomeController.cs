using SpaceInvaders.Business.Controllers.Base;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Business.Services.ComputerPlayer;
using SpaceInvaders.Business.Services.Interfaces;
using SpaceInvaders.Shared.Base.Factory;
using SpaceInvaders.Shared.Base.View;
using SpaceInvaders.Shared.Base.Window;
using SpaceInvaders.Shared.Repository;
using SpaceInvaders.Shared.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using SpaceInvaders.Presentation.Views.Profile;

namespace SpaceInvaders.Business.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IFactory<IBoardStrategy, Strategies> _strategyFactory;
        private readonly IMediate _mediator;

        public string Name { get; set; }

        public HomeController(IList<IView> views, IWindowFascade windowFascade, IPlayerRepository playerRepository, IMediate mediator) : 
            base(views, windowFascade)
        {
            _playerRepository = playerRepository;
            _mediator = mediator;
            _strategyFactory = new StrategyFactory();
        }

        public void ShowProfiles()
        {
            var playerQuery = new PlayerListQuery();
            ChangeView(Contracts.Contracts.HomeView, _mediator.Request(playerQuery));
            WindowFacade.View.AddController(this);
        }

        public void ShowGame(string parameter)
        {
            var strategyDifficulty = Int32.Parse(parameter, NumberStyles.Any);
            var strategy = _strategyFactory.Create((Strategies)strategyDifficulty, Name);
            var controller = ChangeController(Contracts.Contracts.GameController, strategy);
            WindowFacade.ChangeController(controller);
        }

        public void SelectProfile(string sentence)
        {
            var context = new Context(_playerRepository);

            var client = new Client(context);

            var player = client.Interpret(sentence);

            Name = player.Name;

            ChangeView(Contracts.Contracts.MenuView);

            WindowFacade.View.AddController(this);
        }

    }
}
