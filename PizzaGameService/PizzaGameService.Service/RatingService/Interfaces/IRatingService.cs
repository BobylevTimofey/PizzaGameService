using PizzaGameService.Service.RatingService.Responses;

namespace PizzaGameService.Service.RatingService.Interfaces;

public interface IRatingService
{
    Task<IReadOnlyList<PlayerRatingResponse>> GetLeaderboard();

    Task<PlayerRatingResponse> GetPlayerRating(int idPlayer);
}