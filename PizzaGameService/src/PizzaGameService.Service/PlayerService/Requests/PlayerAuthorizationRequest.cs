using System.Text.Json.Serialization;

namespace PizzaGameService.Service.PlayerService.Requests;

public record PlayerAuthorizationRequest
{
    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("password")] public required string Password { get; init; }
}