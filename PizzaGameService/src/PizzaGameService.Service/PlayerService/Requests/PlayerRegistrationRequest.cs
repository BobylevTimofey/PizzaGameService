using System.Text.Json.Serialization;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Service.PlayerService.Requests;

public record PlayerRegistrationRequest
{
    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("password")] public required string Password { get; init; }

    [JsonPropertyName("email")] public required string Email { get; init; }

    [JsonPropertyName("age")] public int? Age { get; init; }

    [JsonPropertyName("gender")] public Gender? Gender { get; init; }
}