namespace PizzaGameService.Service.TokensService.Models;

public record RefreshToken
{
    public required string Token { get; init; }

    public required DateTime TimeCreated { get; init; }

    public required DateTime TimeExpires { get; init; }
}