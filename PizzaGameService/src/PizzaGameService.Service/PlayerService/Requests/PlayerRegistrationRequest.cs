using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Service.PlayerService.Requests;

public record PlayerRegistrationRequest
{
    [JsonPropertyName("login")] 
    [MinLength(3)]
    [MaxLength(20)]
    public required string Login { get; init; }

    [JsonPropertyName("password")] 
    [MinLength(7)]
    [MaxLength(20)]
    [RegularExpression(@"\w*\d\w*")]
    public required string Password { get; init; }

    [JsonPropertyName("email")] 
    [EmailAddress]
    public required string Email { get; init; }

    [JsonPropertyName("age")] 
    [Range(0,120)]
    public int? Age { get; init; }

    [JsonPropertyName("gender")]
    [Range(0,1)]
    public Gender? Gender { get; init; }
}