using PizzaGameService.Data.Mappers;
using PizzaGameService.Data.Player.Implementations;
using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.PlayerData.Implementations;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayersRating.Implementations;
using PizzaGameService.Data.PlayersRating.Interfaces;
using PizzaGameService.Data.PlayerToken.Implementations;
using PizzaGameService.Data.PlayerToken.Interfaces;

namespace PizzaGameService.Data.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddData(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<RegisteredPlayerMapper>()
            .AddSingleton<PlayerWithRefreshTokenMapper>()
            .AddSingleton<PlayerGameDataMapper>()
            .AddSingleton<IPlayerRepository, PlayerRepository>()
            .AddSingleton<IPlayerActiveRepository, PlayerActiveRepository>()
            .AddSingleton<IPlayersRatingRepository, PlayersRatingRepository>()
            .AddSingleton<IPlayerTokenRepository, PlayerTokenRepository>()
            .AddSingleton<IPlayerDataRepository, PlayerDataRepository>();
    }
}