namespace PizzaGameService.Data.PlayerData.Models;

public record PlayerSetParameters
{
    public required string Login { get; init; }

    public required string Password { get; set; }

    public required string Email { get; init; }

    public int? Age { get; init; }

    public Gender? Gender { get; init; }
}