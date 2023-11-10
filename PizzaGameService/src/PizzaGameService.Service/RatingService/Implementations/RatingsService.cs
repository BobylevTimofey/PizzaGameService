using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayersRating.Interfaces;
using PizzaGameService.Service.RatingService.Interfaces;
using PizzaGameService.Service.RatingService.Responses;

namespace PizzaGameService.Service.RatingService.Implementations;

public class RatingsService : IRatingsService
{
    private readonly IPlayersRatingRepository _ratingRepository;
    private readonly IPlayerRepository _playerRepository;

    public RatingsService(IPlayersRatingRepository ratingRepository, IPlayerRepository playerRepository)
    {
        _ratingRepository = ratingRepository;
        _playerRepository = playerRepository;
    }

    public async Task<IReadOnlyList<PlayerRatingResponse>> GetLeaderboard()
    {
        var leaderboard = new List<PlayerRatingResponse>();
        var topPlayers = await _ratingRepository.GetTopPlayers();

        for (int i = 1; i <= topPlayers.Count; i++)
        {
            var playerInLeaderboard = new PlayerRatingResponse
            {
                PlaceInTop = i,
                Login = topPlayers[i].Login,
                Rating = topPlayers[i].Rating
            };

            leaderboard.Add(playerInLeaderboard);
        }

        return leaderboard;
    }

    public async Task<PlayerRatingResponse> GetPlayerRating(int idPlayer)
    {
        var player = await _playerRepository.GetPlayer(idPlayer);
        var playerPlaceInTop = await _ratingRepository.GetPlayerPlaceInTop(idPlayer);

        var playerInLeaderboard = new PlayerRatingResponse
        {
            PlaceInTop = playerPlaceInTop,
            Login = player.Login,
            Rating = player.Rating
        };

        return playerInLeaderboard;
    }
}