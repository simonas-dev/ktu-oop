using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository.Interface;
using System.Collections.Generic;

namespace SpaceInvaders.Shared.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _list;

        public PlayerRepository()
        {
            _list = new List<Player>
            {
                new Player() { Name = "Hank" },
                new Player() { Name = "John" },
                new Player() { Name = "Paul" }
            };
        }

        public IList<Player> GetPlayerProfiles()
        {         
            return _list;
        }

        public void SaveProfile(string name)
        {
            _list.Add(new Player() { Name=name });
        }
    }
}
