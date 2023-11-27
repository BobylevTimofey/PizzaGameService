

using PizzaGameService.Service.PlayerService.Requests;

namespace PizzaGameService.Service.PlayerService.Interfaces;

public interface IPlayerAuthorizationService
{
    Task<int> SingIn(PlayerAuthorizationRequest player);

    Task SignUp(PlayerRegistrationRequest player);
}