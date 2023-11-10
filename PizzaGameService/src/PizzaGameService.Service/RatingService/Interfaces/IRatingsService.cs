using PizzaGameService.Data.PlayersRating.Models;

namespace PizzaGameService.Service.RatingService.Interfaces;

public interface IRatingsService
{
    Task<IReadOnlyList<PlayerLeaderboardResponse>> GetLeaderboard(int countPlayers);

    Task<PlayerLeaderboardResponse> GetPlayerRating(int idPlayer);
}