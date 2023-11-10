using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PizzaGameService.Data.PlayersRating.Interfaces;
using PizzaGameService.Data.PlayersRating.Models;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.PlayersRating.Implementations;

public class PlayersRatingRepository : IPlayersRatingRepository
{
    private readonly string _connectionString;

    public PlayersRatingRepository(IOptions<ConnectionStringSettings> connectionString)
    {
        _connectionString = connectionString.Value.PostgreSql;
    }

    public async Task<IReadOnlyList<PlayerLeaderboardResponse>> GetTopPlayers(int countPlayers)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            $"SELECT login, rating, ROW_NUMBER() OVER (ORDER BY rating DESC)" +
            $" AS placeInTop FROM players LIMIT {countPlayers}";

        var topPlayers = await connection.QueryAsync<PlayerLeaderboardResponse>(sqlCommand);

        return topPlayers.ToList();
    }

    public async Task<PlayerLeaderboardResponse?> GetPlayerPlaceInTop(int idPlayer)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);

        var sqlCommand =
            $"SELECT login, rating, placeInTop FROM (SELECT id, login, rating, " +
            $"ROW_NUMBER() OVER (ORDER BY rating DESC) AS placeInTop FROM players) subquery WHERE id = {idPlayer}";

        var playersInTop = await connection.QuerySingleAsync<PlayerLeaderboardResponse>(sqlCommand);

        return playersInTop;
    }
}