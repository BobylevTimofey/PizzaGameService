using Microsoft.Extensions.DependencyInjection;
using PizzaGameService.Service.PlayerService.Implementations;
using PizzaGameService.Service.PlayerService.Interfaces;

namespace PizzaGameService.Service.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<IPlayerAuthorizationService, PlayerAuthorizationService>();
    }
}