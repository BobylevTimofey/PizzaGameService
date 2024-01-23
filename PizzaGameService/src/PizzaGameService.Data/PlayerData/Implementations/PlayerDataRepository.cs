using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayerData.Models;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.PlayerData.Implementations;

public class PlayerDataRepository : IPlayerDataRepository
{
    private readonly string _connectionString;

    public PlayerDataRepository(IOptions<AppSettings> connectionString)
    {
        _connectionString = connectionString.Value.ConnectionString;
    }

    public async Task SetPlayerData(int idPlayer)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            "INSERT INTO playersData (player_id, seeds_mushroom_amount, seeds_onion_amount, seeds_pepper_amount," +
            " seeds_basil_amount, seeds_tomato_amount, seeds_olive_amount, dough_amount, egg_amount, flour_amount," +
            " water_amount, sauce_amount, cheese_amount, sausage_amount, mushrooms_amount, onions_amount," +
            " peppers_amount, basils_amount, tomatoes_amount, anchovies_amount, pineapples_amount, balance," +
            " garden_level, cafe_level, kitchen_level, days_amount, rating)" +
            $"VALUES ({idPlayer}, 0, 0, 0, 0," +
            "0, 0, 0, 5, 5, 0, 0," +
            "5, 0, 0, 0, 0, 0, 5," +
            "0, 0, 1000, 0, 0, 0, 0, 100)";

        await connection.QueryAsync(sqlCommand);
    }

    public async Task UpdatePlayerData(int idPlayer, PlayerGameData playerData)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            "UPDATE playersData SET seeds_mushroom_amount = @SeedsMushroomAmount, seeds_onion_amount = @SeedsOnionAmount, seeds_pepper_amount = @SeedsPepperAmount," +
            " seeds_basil_amount = @SeedsBasilAmount, seeds_tomato_amount = @SeedsTomatoAmount, seeds_olive_amount = @SeedsOliveAmount, dough_amount = @DoughAmount, egg_amount = @EggAmount, flour_amount = @FlourAmount," +
            " water_amount = @WaterAmount, sauce_amount = @SauceAmount, cheese_amount = @CheeseAmount, sausage_amount = @SausageAmount, mushrooms_amount = @MushroomAmount, onions_amount = @OnionsAmount," +
            " peppers_amount = @PeppersAmount, basils_amount = @BasilsAmount, tomatoes_amount = @TomatoesAmount, anchovies_amount = @AnchoviesAmount, pineapples_amount = @PineapplesAmount, balance = @Balance," +
            $" garden_level = @GardenLevel, cafe_level = @CafeLevel, kitchen_level = @KitchenLevel, days_amount = @DaysAmount, rating = @Rating WHERE player_id = {idPlayer}";

        await connection.QueryAsync(sqlCommand, playerData);
    }

    public async Task<PlayerGameData> GetPlayerData(int idPlayer)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            "SELECT * FROM playersdata WHERE player_id = @idPlayer";

        var players = await connection.QuerySingleAsync<PlayerGameData>(sqlCommand, new { idPlayer });

        return players;
    }
}