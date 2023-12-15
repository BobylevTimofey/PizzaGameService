using Dapper.FluentMap.Mapping;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.Mappers;

public class PlayerGameDataMapper : EntityMap<PlayerGameData>
{
    public PlayerGameDataMapper()
    {
        Map(playerGameData => playerGameData.Balance).ToColumn("balance");
        Map(playerGameData => playerGameData.Rating).ToColumn("rating");
        Map(playerGameData => playerGameData.AnchoviesAmount).ToColumn("anchovies_amount");
        Map(playerGameData => playerGameData.CheeseAmount).ToColumn("cheese_amount");
        Map(playerGameData => playerGameData.BasilsAmount).ToColumn("basils_amount");
        Map(playerGameData => playerGameData.CafeLevel).ToColumn("cafe_level");
        Map(playerGameData => playerGameData.DaysAmount).ToColumn("days_amount");
        Map(playerGameData => playerGameData.DoughAmount).ToColumn("dough_amount");
        Map(playerGameData => playerGameData.EggAmount).ToColumn("egg_amount");
        Map(playerGameData => playerGameData.FlourAmount).ToColumn("flour_amount");
        Map(playerGameData => playerGameData.GardenLevel).ToColumn("garden_level");
        Map(playerGameData => playerGameData.KitchenLevel).ToColumn("kitchen_level");
        Map(playerGameData => playerGameData.MushroomAmount).ToColumn("mushroom_amount");
        Map(playerGameData => playerGameData.OnionsAmount).ToColumn("onions_amount");
        Map(playerGameData => playerGameData.PeppersAmount).ToColumn("peppers_amount");
        Map(playerGameData => playerGameData.PineapplesAmount).ToColumn("pineapples_amount");
        Map(playerGameData => playerGameData.SauceAmount).ToColumn("sauce_amount");
        Map(playerGameData => playerGameData.SausageAmount).ToColumn("sausage_amount");
        Map(playerGameData => playerGameData.TomatoesAmount).ToColumn("tomatoes_amount");
        Map(playerGameData => playerGameData.WaterAmount).ToColumn("water_amount");
        Map(playerGameData => playerGameData.SeedsBasilAmount).ToColumn("seeds_basil_amount");
        Map(playerGameData => playerGameData.SeedsMushroomAmount).ToColumn("seeds_mushroom_amount");
        Map(playerGameData => playerGameData.SeedsOliveAmount).ToColumn("seeds_olive_amount");
        Map(playerGameData => playerGameData.SeedsPepperAmount).ToColumn("seeds_pepper_amount");
        Map(playerGameData => playerGameData.SeedsTomatoAmount).ToColumn("seeds_tomato_amount");
        Map(playerGameData => playerGameData.SeedsOnionAmount).ToColumn("seeds_onion_amount");
    }
}