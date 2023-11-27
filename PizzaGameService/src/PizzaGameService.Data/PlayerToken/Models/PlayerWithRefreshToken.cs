namespace PizzaGameService.Data.PlayerToken.Models;

public record PlayerWithRefreshToken
{
    public required int Id { get; init; }
    
    public required string RefreshToken { get; init; }
    
    public required DateTime TimeTokenCreated { get; init; }
    
    public required DateTime TimeTokenExpires { get; init; }
}