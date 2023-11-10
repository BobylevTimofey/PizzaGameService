using Microsoft.Extensions.DependencyInjection;
using PizzaGameService.Service.PlayerService.Implementations;
using PizzaGameService.Service.RatingService.Implementations;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.RatingService.Interfaces;

namespace PizzaGameService.Service.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IPlayerAuthorizationService, PlayerAuthorizationService>()
            .AddSingleton<IRatingsService, RatingsService>();
    }
}