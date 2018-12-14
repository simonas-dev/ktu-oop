using System.Collections.Generic;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository.Interface;

namespace SpaceInvaders.Shared.Repository
{
    public class PlayerRepoProxy : IPlayerRepository
    {
        IPlayerRepository parentProxy = null;

        public PlayerRepoProxy(IPlayerRepository repo)
        {
            parentProxy = repo;
        }

        public IList<Player> GetPlayerProfiles()
        {
            return parentProxy.GetPlayerProfiles();
        }

        public void SaveProfile(string name)
        {
            parentProxy.SaveProfile(name);
        }
    }
}
