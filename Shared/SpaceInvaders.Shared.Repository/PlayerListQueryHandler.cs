using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository.Interface;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Shared.Repository
{
    public class PlayerListQueryHandler : IHandleQueries<IQuery<List<Player>>, List<Player>>
    {
        public List<Player> Handle(IQuery<List<Player>> query)
        {
            var playerQuery = query as PlayerListQuery;

            return PlayerDbContext.GetPlayerProfiles();
        }

        public bool CanHandle(Type commandType)
        {
            return commandType == typeof(PlayerListQuery);
        }
    }
}