using System.Text.Json.Serialization;

namespace PizzaGameService.Service.RatingService.Responses;

public record PlayerRatingResponse
{
    [JsonPropertyName("placeInTop")] public required int PlaceInTop { get; init; }

    [JsonPropertyName("login")] public required string Login { get; init; }

    [JsonPropertyName("rating")] public required int Rating { get; init; }
}