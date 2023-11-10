using System.Text.Json.Serialization;

namespace PizzaGameService.Data.PlayersRating.Models;

public class PlayerLeaderboardResponse
{
    [JsonPropertyName("placeInTop")] public required int PlaceInTop { get; init; }

    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("rating")] public required int Rating { get; init; }
}