using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.PlayerData.Implementations;

public class PlayerRepository : IPlayerRepository
{
    public Task<int> SetPlayer(PlayerSetParameters player)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers()
    {
        throw new NotImplementedException();
    }
}