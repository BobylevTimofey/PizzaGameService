using Microsoft.Extensions.Options;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.Settings;

namespace PizzaGameService.Data.PlayerData.Implementations;

public class PlayerActiveRepository : IPlayerActiveRepository
{
    private readonly IOptions<AppSettings> _connectionString;

    public PlayerActiveRepository(IOptions<AppSettings> settings)
    {
        _connectionString = settings;
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