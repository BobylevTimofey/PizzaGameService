using Microsoft.Extensions.Options;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.PlayerData.Implementations;

public class PlayerActiveRepository : IPlayerActiveRepository
{
    private readonly IOptions<ConnectionStringSettings> _connectionString;

    public PlayerActiveRepository(IOptions<ConnectionStringSettings> connectionString)
    {
        _connectionString = connectionString;
    }

    public Task SetPlayerActive(int id)
    {
        throw new NotImplementedException();
    }

    public Task SetPlayerInactive(int id)
    {
        throw new NotImplementedException();
    }
}