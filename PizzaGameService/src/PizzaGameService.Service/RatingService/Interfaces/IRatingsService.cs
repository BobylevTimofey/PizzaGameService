using PizzaGameService.Service.RatingService.Responses;

namespace PizzaGameService.Service.RatingService.Interfaces;

public interface IRatingsService
{
    Task<IReadOnlyList<PlayerRatingResponse>> GetLeaderboard();

    Task<PlayerRatingResponse> GetPlayerRating(int idPlayer);
}