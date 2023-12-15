namespace PizzaGameService.Data.Player.Models;

public class RegisteredPlayer
{
    public required int Id { get; init; }

    public required string Login { get; init; }

    public required string Password { get; set; }

    public required string Email { get; init; }

    public required bool IsPlaying { get; init; }
}