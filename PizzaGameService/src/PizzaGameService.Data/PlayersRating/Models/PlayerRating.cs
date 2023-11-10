namespace PizzaGameService.Data.PlayersRating.Models;

public record PlayerRating
{
    public required string Login { get; init; }
    
    public required int Rating { get; init; }
}