using System.Security.Claims;
using PizzaGameService.Service.Exceptions;

namespace PizzaGameService.Service.TokensService.Utilities;

public static class TokenUtility
{
    public static int GetIdPlayer(ClaimsPrincipal user)
    {
        return int.Parse(user.Claims
            .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)
            ?.Value ?? throw new PlayerNotVerifyException("Incorrect token"));
    }
}