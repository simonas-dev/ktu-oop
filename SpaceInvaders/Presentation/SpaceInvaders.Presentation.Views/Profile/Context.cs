using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Shared.Repository;
using SpaceInvaders.Shared.Repository.Interface;

namespace SpaceInvaders.Presentation.Views.Profile
{
    public class Context
    {
        private readonly IPlayerRepository _playerRepo;

        public Context(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public IList<Player> GetAllPlayers()
        {
            return _playerRepo.GetPlayerProfiles();
        }

        public Player AddPlayer(Player player)
        {
            _playerRepo.SaveProfile(player.Name);
            return player;
        }
    }
}