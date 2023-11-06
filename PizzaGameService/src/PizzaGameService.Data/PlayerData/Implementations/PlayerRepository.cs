using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayerData.Models;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.PlayerData.Implementations;

public class PlayerRepository : IPlayerRepository
{
    private readonly string _connectionString;

    public PlayerRepository(IOptions<ConnectionStringSettings> connectionString)
    {
        _connectionString = connectionString.Value.PostgreSql;
    }

    public async Task<int> SetPlayer(PlayerSetParameters player)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        const int baseRating = 0;

        var sqlCommand =
            "INSERT INTO players (login, password, email, age, gender, rating) " +
            $"VALUES (@Login, @Password, @Email, @Age, @Gender, {baseRating}) RETURNING id";

        var idPlayers = await connection.QueryAsync<int>(sqlCommand, player);

        return idPlayers.FirstOrDefault();
    }

    public async Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers()
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand = "SELECT * FROM players";

        var players = await connection.QueryAsync<RegisteredPlayer>(sqlCommand);

        return players.ToList();
    }
}