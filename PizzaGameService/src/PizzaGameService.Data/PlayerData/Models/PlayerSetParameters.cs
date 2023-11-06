using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayerData.Models;

public record PlayerSetParameters
{
    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("password")] public required string Password { get; set; }

    [JsonPropertyName("email")] public required string Email { get; init; }

    [JsonPropertyName("age")] public int? Age { get; init; }

    [JsonPropertyName("gender")] public Gender? Gender { get; init; }
}