using PizzaGameService.Data.PlayersRating.Models;

namespace PizzaGameService.Data.PlayersRating.Interfaces;

public interface IPlayersRatingRepository
{
    Task<IReadOnlyList<PlayerLeaderboardResponse>> GetTopPlayers(int countPlayers);

    Task<PlayerLeaderboardResponse?> GetPlayerPlaceInTop(int idPlayer);
}