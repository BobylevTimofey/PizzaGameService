using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayerData.Models;

public record PlayerSetParameters
{
    [JsonPropertyName("login")]
    public required string PlayerLogin { get; init; }
    
    [JsonPropertyName("passwoed")]
    public required string PlayerPassword { get; set; }
    
    [JsonPropertyName("email")]
    public required string PlayerEmail { get; init; }
    
    [JsonPropertyName("age")]
    public int? PlayerAge { get; init; }
    
    [JsonPropertyName("gender")]
    public Gender? PlayerGender { get; init; }
    
    [JsonPropertyName("rating")] 
    public int? PlayerRating { get; init; } = 0;
}