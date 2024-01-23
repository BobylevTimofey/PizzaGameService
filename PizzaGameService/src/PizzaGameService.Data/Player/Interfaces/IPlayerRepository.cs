using PizzaGameService.Data.Player.Models;

namespace PizzaGameService.Data.Player.Interfaces;

public interface IPlayerRepository
{
    Task<int> SetPlayer(PlayerSetParameters player);

    Task UpdatePlayerBestRating(int idPlayer, int rating);
    
    Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers();
}