using PizzaGameService.Data.PlayersRating.Models;

namespace PizzaGameService.Data.PlayersRating.Interfaces;

public interface IPlayersRatingRepository
{
    Task<IReadOnlyList<PlayerRating>> GetTopPlayers();

    Task<int> GetPlayerPlaceInTop(int idPlayer);
}