using PizzaGameService.Data.Mappers;
using PizzaGameService.Data.PlayerData.Implementations;
using PizzaGameService.Data.PlayerData.Interfaces;

namespace PizzaGameService.Data.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddData(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<RegisteredPlayerMapper>()
            .AddSingleton<IPlayerRepository, PlayerRepository>()
            .AddSingleton<IPlayerActiveRepository, PlayerActiveRepository>();
    }
}