using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository.Interface;
using System;

namespace SpaceInvaders.Shared.Repository
{
    public class PlayerQueryHandler : IHandleQueries<IQuery<Player>, Player>
    {
        public Player Handle(IQuery<Player> query)
        {
            var playerQuery = query as PlayerQuery;
            return PlayerDbContext.GetPlayer(playerQuery.Name);
        }

        public bool CanHandle(Type commandType)
        {
            return commandType == typeof(PlayerQuery);
        }
    }
}