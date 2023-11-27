using PizzaGameService.Data.PlayerToken.Models;

namespace PizzaGameService.Data.PlayerToken.Interfaces;

public interface IPlayerTokenRepository
{
    Task<PlayerWithRefreshToken?> FindPlayerWithRefreshToken(string token);

    Task SetRefreshToken(PlayerWithRefreshToken playerWithToken);
}