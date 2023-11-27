using PizzaGameService.Data.PlayersRating.Interfaces;
using PizzaGameService.Data.PlayersRating.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.RatingService.Interfaces;

namespace PizzaGameService.Service.RatingService.Implementations;

public class RatingsService : IRatingsService
{
    private readonly IPlayersRatingRepository _ratingRepository;

    public RatingsService(IPlayersRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<IReadOnlyList<PlayerLeaderboardResponse>> GetLeaderboard(int countPlayers)
    {
        var leaderboard = await _ratingRepository.GetTopPlayers(countPlayers);

        return leaderboard;
    }

    public async Task<PlayerLeaderboardResponse> GetPlayerRating(int idPlayer)
    {
        var playerPlaceInTop = await _ratingRepository.GetPlayerPlaceInTop(idPlayer) ??
                               throw new PlayerNotFoundException(idPlayer.ToString());

        return playerPlaceInTop;
    }
}