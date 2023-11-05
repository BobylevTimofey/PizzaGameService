using System.Text.Json.Serialization;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Service.PlayerService.Requests;

public record PlayerRegistrationRequest
{
    [JsonPropertyName("login")] public required string PlayerLogin { get; init; }

    [JsonPropertyName("password")] public required string PlayerPassword { get; init; }

    [JsonPropertyName("email")] public required string PlayerEmail { get; init; }

    [JsonPropertyName("age")] public int? PlayerAge { get; init; }

    [JsonPropertyName("gender")] public Gender? PlayerGender { get; init; }
}