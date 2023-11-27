using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.PlayerData.Interfaces;

public interface IPlayerRepository
{
    Task SetPlayer(PlayerSetParameters player);
    
    Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers();
}