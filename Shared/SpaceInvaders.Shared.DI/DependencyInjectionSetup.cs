using Autofac;
using SpaceInvaders.Business.Controllers;
using SpaceInvaders.Business.Controllers.Interfaces;
using SpaceInvaders.Presentation.Views;
using SpaceInvaders.Presentation.Views.Interfaces;
using SpaceInvaders.Presentation.Windows.Window;
using SpaceInvaders.Shared.Base.Window;
using SpaceInvaders.Shared.Repository;
using SpaceInvaders.Shared.Repository.Interface;

namespace SpaceInvaders.Shared.DI
{
    public class DependencyInjectionSetup
    {
        public IContainer Container { get; set; }

        public DependencyInjectionSetup()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HomeController>().As<IHomeController>();
            builder.RegisterType<HomeView>().As<IHomeView>();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>();
            builder.RegisterType<Mediator>().As<IMediate>();
            builder.RegisterType<BaseWindowFascade>().As<IWindowFascade>();
            Container = builder.Build();
        }

        public ILifetimeScope GetScope()
        {
            var scope = Container.BeginLifetimeScope();
            return scope;
        }
    }
}
