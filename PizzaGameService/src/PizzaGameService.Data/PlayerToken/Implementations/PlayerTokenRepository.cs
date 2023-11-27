using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PizzaGameService.Data.PlayerToken.Interfaces;
using PizzaGameService.Data.PlayerToken.Models;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.PlayerToken.Implementations;

public class PlayerTokenRepository : IPlayerTokenRepository
{
    private readonly string _connectionString;

    public PlayerTokenRepository(IOptions<AppSettings> settings)
    {
        _connectionString = settings.Value.ConnectionString;
    }

    public async Task<PlayerWithRefreshToken?> FindPlayerWithRefreshToken(string token)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            $"SELECT id, refresh_token, time_token_created, time_token_expires FROM players WHERE refresh_token =\'{token}\'";
        return await connection.QuerySingleAsync<PlayerWithRefreshToken>(sqlCommand);
    }

    public async Task SetRefreshToken(PlayerWithRefreshToken playerWithToken)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);
        var sqlCommand =
            $"UPDATE players SET refresh_token = @RefreshToken, time_token_created = @TimeTokenCreated," +
            $" time_token_expires = @TimeTokenExpires WHERE id = @Id";

        await connection.QueryAsync(sqlCommand, playerWithToken);
    }
}