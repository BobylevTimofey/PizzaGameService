using Microsoft.AspNetCore.Http;
using PizzaGameService.Data.PlayerToken.Models;
using PizzaGameService.Service.TokensService.Models;

namespace PizzaGameService.Service.TokensService.Interfaces;

public interface ITokenService
{
    string CreateJwt(int id);
    
    RefreshToken CreateRefreshToken();

    Task SetRefreshToken(HttpResponse response, RefreshToken token, int playerId);

    Task<PlayerWithRefreshToken> GetPlayerWithToken(string token);
}