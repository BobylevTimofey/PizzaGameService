using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayerData.Models;

public class RegisteredPlayer
{
    [JsonPropertyName("id")] public required int Id { get; init; }

    [JsonPropertyName("login")] public required string PlayerLogin { get; init; }

    [JsonPropertyName("password")] public required string PlayerPassword { get; set; }

    [JsonPropertyName("email")] public required string PlayerEmail { get; init; }

    [JsonPropertyName("isPlaying")] public required bool IsPlaying { get; init; }
}