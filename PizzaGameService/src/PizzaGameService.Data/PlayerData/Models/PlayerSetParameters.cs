using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayerData.Models;

public record PlayerSetParameters
{
    [JsonPropertyName("login")] public required string PlayerLogin { get; init; }

    [JsonPropertyName("password")] public required string PlayerPassword { get; set; }

    [JsonPropertyName("email")] public required string PlayerEmail { get; init; }

    [JsonPropertyName("age")] public int? PlayerAge { get; init; }

    [JsonPropertyName("gender")] public Gender? PlayerGender { get; init; }
}