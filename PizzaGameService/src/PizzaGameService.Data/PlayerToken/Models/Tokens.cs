using System.Collections;
using System.Text;
using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayerToken.Models;

public record Tokens
{
    [JsonPropertyName("token")] public required string Token { get; init; }

    [JsonPropertyName("refreshToken")] public required string RefreshToken { get; init; }
}

