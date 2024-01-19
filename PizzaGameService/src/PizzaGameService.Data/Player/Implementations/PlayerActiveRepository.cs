using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.Player.Implementations;

public class PlayerActiveRepository : IPlayerActiveRepository
{
    private readonly string _connectionString;

    public PlayerActiveRepository(IOptions<AppSettings> settings)
    {
        _connectionString = settings.Value.ConnectionString;
    }

    public async Task SetPlayerActive(int idPlayer, bool isActive)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand = $"UPDATE players SET is_playing = {isActive} WHERE id = {idPlayer}";

        await connection.ExecuteAsync(sqlCommand);
    }

    public async Task<bool> GetPlayerActive(int idPlayer)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand = $"SELECT is_playing FROM players WHERE id = {idPlayer}";

        return await connection.QuerySingleAsync<bool>(sqlCommand);
    }
}