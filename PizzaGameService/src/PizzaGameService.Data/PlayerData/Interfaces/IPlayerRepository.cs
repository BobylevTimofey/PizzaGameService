using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.PlayerData.Interfaces;

public interface IPlayerRepository
{
    Task<int> SetPlayer(PlayerSetParameters player);
    
    Task<Player> GetPlayer(int idPlayer);

    Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers();
}