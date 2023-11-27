using Microsoft.AspNetCore.Mvc;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.PlayerService.Requests;
using PizzaGameService.Service.TokensService.Interfaces;

namespace PizzaGameService.Api.Controllers.PlayerController;

[Route("api/v1/player")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerAuthorizationService _authorizationService;
    private readonly ITokenService _tokenService;

    public PlayerController(IPlayerAuthorizationService authorizationService, ITokenService tokenService)
    {
        _authorizationService = authorizationService;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("registration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> RegisterPlayer(PlayerRegistrationRequest request)
    {
        try
        {
            await _authorizationService.SignUp(request);

            return Created(string.Empty, null);
        }
        catch (PlayerAlreadyRegisteredException exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpPost]
    [Route("authorization")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<string>> AuthorizePlayer(PlayerAuthorizationRequest request)
    {
        try
        {
            var playerId = await _authorizationService.SingIn(request);
            var token = _tokenService.CreateJwt(playerId);

            var refreshToken = _tokenService.CreateRefreshToken();
            await _tokenService.SetRefreshToken(Response, refreshToken, playerId);

            return Ok(token);
        }
        catch (PlayerNotVerifyException exception)
        {
            return Unauthorized(exception.Message);
        }
        catch (PlayerAlreadyPlayingException exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpPost]
    [Route("authorization/refresh_token")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<string>> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (refreshToken is null)
            return Unauthorized();
        try
        {
            var playerWithRefreshToken = await _tokenService.GetPlayerWithToken(refreshToken);

            if (!playerWithRefreshToken.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid refresh token");
            }

            if (playerWithRefreshToken.TimeTokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired");
            }

            var newToken = _tokenService.CreateJwt(playerWithRefreshToken.Id);
            var newRefreshToken = _tokenService.CreateRefreshToken();
            await _tokenService.SetRefreshToken(Response, newRefreshToken, playerWithRefreshToken.Id);

            return Created(string.Empty, newToken);
        }
        catch (Exception exception)
        {
            return Unauthorized(exception);
        }
    }
}