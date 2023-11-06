using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayerData.Models;

public class RegisteredPlayer
{
    [JsonPropertyName("id")] public required int Id { get; init; }

    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("password")] public required string Password { get; set; }

    [JsonPropertyName("email")] public required string Email { get; init; }

    [JsonPropertyName("isPlaying")] public required bool IsPlaying { get; init; }
}