using SpaceInvaders.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpaceInvaders.Shared.Repository
{
    public static class PlayerDbContext
    {
        private static readonly List<Player> _list = new List<Player>
        {
            new Player() { Name = "Hank" },
            new Player() { Name = "John" },
            new Player() { Name = "Paul" },
            new Player() { Name = "Justtest" }
        };


        public static List<Player> GetPlayerProfiles()
        {
            return _list;
        }

        public static Player GetPlayer(string name)
        {
            return _list.SingleOrDefault(p => p.Name == name);
        }

        public static void SaveProfile(string name)
        {
            _list.Add(new Player() { Name = name });
        }
    }
}