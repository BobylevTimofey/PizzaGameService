namespace PizzaGameService.Data.PlayerData.Models;

public record PlayerGameData
{
    public required int SeedsMushroomAmount { get; init; }

    public required int SeedsOnionAmount { get; init; }

    public required int SeedsPepperAmount { get; init; }

    public required int SeedsBasilAmount { get; init; }

    public required int SeedsTomatoAmount { get; init; }

    public required int SeedsOliveAmount { get; init; }

    public required int DoughAmount { get; init; }

    public required int EggAmount { get; init; }

    public required int FlourAmount { get; init; }

    public required int WaterAmount { get; init; }

    public required int SauceAmount { get; init; }

    public required int CheeseAmount { get; init; }

    public required int SausageAmount { get; init; }

    public required int MushroomAmount { get; init; }

    public required int OnionsAmount { get; init; }

    public required int PeppersAmount { get; init; }

    public required int BasilsAmount { get; init; }

    public required int TomatoesAmount { get; init; }

    public required int AnchoviesAmount { get; init; }

    public required int PineapplesAmount { get; init; }

    public required int Balance { get; init; }

    public required int Rating { get; init; }

    public required int GardenLevel { get; init; }

    public required int CafeLevel { get; init; }

    public required int KitchenLevel { get; init; }

    public required int DaysAmount { get; init; }
}