using PizzaGameService.Data.Mappers;
using PizzaGameService.Data.PlayerData.Implementations;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayersRating.Implementations;
using PizzaGameService.Data.PlayersRating.Interfaces;

namespace PizzaGameService.Data.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddData(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<RegisteredPlayerMapper>()
            .AddSingleton<IPlayerRepository, PlayerRepository>()
            .AddSingleton<IPlayerActiveRepository, PlayerActiveRepository>()
            .AddSingleton<IPlayersRatingRepository, PlayersRatingRepository>();
    }
}