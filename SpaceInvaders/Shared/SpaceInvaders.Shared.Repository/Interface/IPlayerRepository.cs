using System.Collections;
using System.Collections.Generic;
using SpaceInvaders.Domain.Models;

namespace SpaceInvaders.Shared.Repository.Interface
{
    public interface IPlayerRepository
    {
        IList<Player> GetPlayerProfiles();
        void SaveProfile(string name);
    }
}