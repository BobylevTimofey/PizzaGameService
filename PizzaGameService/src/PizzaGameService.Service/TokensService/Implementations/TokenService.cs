using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PizzaGameService.Data.PlayerToken.Interfaces;
using PizzaGameService.Data.PlayerToken.Models;
using PizzaGameService.Data.Settings;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.TokensService.Interfaces;
using PizzaGameService.Service.TokensService.Models;

namespace PizzaGameService.Service.TokensService.Implementations;

public class TokenService : ITokenService
{
    private readonly string _token;
    private readonly IPlayerTokenRepository _tokenRepository;

    public TokenService(IOptions<AppSettings> settings, IPlayerTokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
        _token = settings.Value.Token;
    }

    public string CreateJwt(int id)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, id.ToString())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_token));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public RefreshToken CreateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            TimeCreated = DateTime.Now,
            TimeExpires = DateTime.Now.AddDays(7)
        };

        return refreshToken;
    }

    public async Task SetRefreshToken(HttpResponse response, RefreshToken token, int playerId)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = token.TimeExpires
        };

        response.Cookies.Append("refreshToken", token.Token, cookieOptions);

        var playerWithRefreshToken = new PlayerWithRefreshToken
        {
            Id = playerId,
            RefreshToken = token.Token,
            TimeTokenCreated = token.TimeCreated,
            TimeTokenExpires = token.TimeExpires
        };

        await _tokenRepository.SetRefreshToken(playerWithRefreshToken);
    }

    public async Task<PlayerWithRefreshToken> GetPlayerWithToken(string token)
    {
        var playerWithRefreshToken = await _tokenRepository.FindPlayerWithRefreshToken(token);
        
        if (playerWithRefreshToken is null)
            throw new PlayerNotFoundException(token);

        return playerWithRefreshToken;
    }
}