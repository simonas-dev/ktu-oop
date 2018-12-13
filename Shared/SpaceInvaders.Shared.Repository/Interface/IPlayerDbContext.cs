using System;
using System.Collections.Generic;
using SpaceInvaders.Domain.Models;

namespace SpaceInvaders.Shared.Repository.Interface
{
    public interface IPlayerDbContext
    {
        List<Player> GetPlayerProfiles();
        Player GetPlayer(string name);
        void SaveProfile(string name);
    }
}
