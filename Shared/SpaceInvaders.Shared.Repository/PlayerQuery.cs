using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository.Interface;

namespace SpaceInvaders.Shared.Repository
{
    public class PlayerQuery : IQuery<Player>
    {
        public string Name { get; private set; }

        public PlayerQuery(string name)
        {
            Name = name;
        }
    }
}