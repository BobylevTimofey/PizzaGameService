using Microsoft.Extensions.DependencyInjection;
using PizzaGameService.Service.PlayerGameDataService.Implementations;
using PizzaGameService.Service.PlayerGameDataService.Interfaces;
using PizzaGameService.Service.PlayerService.Implementations;
using PizzaGameService.Service.RatingService.Implementations;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.RatingService.Interfaces;
using PizzaGameService.Service.TokensService.Implementations;
using PizzaGameService.Service.TokensService.Interfaces;

namespace PizzaGameService.Service.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IPlayerAuthorizationService, PlayerAuthorizationService>()
            .AddSingleton<IRatingsService, RatingsService>()
            .AddSingleton<ITokenService, TokenService>()
            .AddSingleton<IPlayerDataService, PlayerDataService>();
    }
}