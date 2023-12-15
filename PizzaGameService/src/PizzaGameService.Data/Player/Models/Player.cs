namespace PizzaGameService.Data.Player.Models;

public class Player
{
    public required string Login { get; init; }

    public required string Password { get; set; }

    public required string Email { get; init; }
    
    public required int Rating { get; init; }

    public int? Age { get; init; }

    public Gender? Gender { get; init; }
}