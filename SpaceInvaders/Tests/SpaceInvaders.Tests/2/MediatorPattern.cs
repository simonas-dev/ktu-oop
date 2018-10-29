using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository;
using SpaceInvaders.Shared.Repository.Interface;
using System.Collections.Generic;
using Xunit;

namespace SpaceInvaders.Tests._2
{
    public class MediatorPattern
    {
        [Fact]
        public void ItGets_PlayersFromMediator()
        {
            var mediator = new Mediator();
            mediator.Register<IHandleQueries<IQuery<List<Player>>, List<Player>>>(delegate
            {
                return new PlayerListQueryHandler();
            });
            mediator.Register<IHandleQueries<IQuery<Player>, Player>>(delegate
            {
                return new PlayerQueryHandler();
            });

            mediator.Register<IHandleQueries<IQuery<List<Player>>, List<Player>>, PlayerListQueryHandler>();
            mediator.Register<IHandleQueries<IQuery<Player>, Player>, PlayerQueryHandler>();

            var playerQuery = new PlayerListQuery();
            var players = mediator.Request(playerQuery);

            Assert.NotNull(players);
            Assert.Equal(players.Count, PlayerDbContext.GetPlayerProfiles().Count);
        }

        [Fact]
        public void ItGets_PlayerFromMediator()
        {
            var mediator = new Mediator();
            mediator.Register<IHandleQueries<IQuery<List<Player>>, List<Player>>>(delegate
            {
                return new PlayerListQueryHandler();
            });
            mediator.Register<IHandleQueries<IQuery<Player>, Player>>(delegate
            {
                return new PlayerQueryHandler();
            });

            mediator.Register<IHandleQueries<IQuery<List<Player>>, List<Player>>, PlayerListQueryHandler>();
            mediator.Register<IHandleQueries<IQuery<Player>, Player>, PlayerQueryHandler>();

            var playerQuery = new PlayerQuery("Hank");
            var players = mediator.Request(playerQuery);

            Assert.NotNull(players);
            Assert.Equal(players.Name, PlayerDbContext.GetPlayer("Hank").Name);
        }
    }
}