using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.PlayerData.Interfaces;

public interface IPlayerRepository
{
    Task<int> SetPlayer(PlayerSetParameters player);
    
    Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers();
}