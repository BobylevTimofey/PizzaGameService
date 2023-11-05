using System.Text.Json.Serialization;

namespace PizzaGameService.Service.PlayerService.Requests;

public record PlayerAuthorizationRequest
{
    [JsonPropertyName("login")]
    public required string PlayerLogin { get; init; }
    
    [JsonPropertyName("password")]
    public required string PlayerPassword { get; init; }
}