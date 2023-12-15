using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.Player.Models;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.Player.Implementations;

public class PlayerRepository : IPlayerRepository
{
    private readonly string _connectionString;

    public PlayerRepository(IOptions<AppSettings> settings)
    {
        _connectionString = settings.Value.ConnectionString;
    }

    public async Task<int> SetPlayer(PlayerSetParameters player)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        const int baseRating = 0;

        const bool defaultIsPlaying = false;

        var sqlCommand =
            "INSERT INTO players (login, password, email, is_playing, age, gender, rating) " +
            $"VALUES (@Login, @Password, @Email, {defaultIsPlaying}, @Age, @Gender, {baseRating}) RETURNING id";

        var idPlayers = await connection.QueryAsync<int>(sqlCommand, player);

        return idPlayers.FirstOrDefault();
    }

    public async Task UpdatePlayerRating(int idPlayer, int rating)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            $"UPDATE players SET rating = {rating} WHERE id = {idPlayer}";

        await connection.QueryAsync(sqlCommand);
    }

    public async Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers()
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand = "SELECT * FROM players";

        var players = await connection.QueryAsync<RegisteredPlayer>(sqlCommand);

        return players.ToList();
    }
}