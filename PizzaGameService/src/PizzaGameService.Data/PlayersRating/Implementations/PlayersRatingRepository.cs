using PizzaGameService.Data.PlayersRating.Interfaces;
using PizzaGameService.Data.PlayersRating.Models;

namespace PizzaGameService.Data.PlayersRating.Implementations;

public class PlayersRatingRepository : IPlayersRatingRepository
{
    public Task<IReadOnlyList<PlayerRating>> GetTopPlayers()
    {
        throw new NotImplementedException();
    }

    public Task<int> GetPlayerPlaceInTop(int idPlayer)
    {
        throw new NotImplementedException();
    }
}