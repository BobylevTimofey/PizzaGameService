using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.PlayerToken.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.PlayerService.Requests;
using PizzaGameService.Service.TokensService.Interfaces;
using PizzaGameService.Service.TokensService.Utilities;

namespace PizzaGameService.Api.Controllers.PlayerController;

[Route("api/v1/player")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerAuthorizationService _authorizationService;
    private readonly ITokenService _tokenService;
    private readonly IPlayerPlayingService _playerPlayingService;
    

    public PlayerController(IPlayerAuthorizationService authorizationService, ITokenService tokenService, IPlayerActiveRepository playerActiveRepository, IPlayerPlayingService playerPlayingService)
    {
        _authorizationService = authorizationService;
        _tokenService = tokenService;
        _playerPlayingService = playerPlayingService;
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
    public async Task<ActionResult<Tokens>> AuthorizePlayer(PlayerAuthorizationRequest request)
    {
        try
        {
            var playerId = await _authorizationService.SingIn(request);
            var token = _tokenService.CreateJwt(playerId);

            var refreshToken = _tokenService.CreateRefreshToken();
            await _tokenService.SetRefreshToken(refreshToken, playerId);

            var tokens = new Tokens
            {
                Token = token,
                RefreshToken = refreshToken.Token
            };

            return Ok(tokens);
        }
        catch (PlayerNotVerifyException exception)
        {
            return Unauthorized(exception.Message);
        }
    }

    [HttpGet]
    [Route("authorization/refresh_token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Tokens>> RefreshToken()
    {
        var refreshToken = HttpContext.Request.Headers["refreshToken"];
        
        if (string.IsNullOrEmpty(refreshToken))
            return Unauthorized();
        try
        {
            var playerWithRefreshToken = await _tokenService.GetPlayerWithToken(refreshToken.ToString());

            if (playerWithRefreshToken.TimeTokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired");
            }

            var newToken = _tokenService.CreateJwt(playerWithRefreshToken.Id);
            var newRefreshToken = _tokenService.CreateRefreshToken();
            await _tokenService.SetRefreshToken(newRefreshToken, playerWithRefreshToken.Id);

            var tokens = new Tokens
            {
                Token = newToken,
                RefreshToken = newRefreshToken.Token
            };

            return Ok(tokens);
        }
        catch (Exception exception)
        {
            return Unauthorized(exception);
        }
    }
    
    [HttpGet]
    [Route("play")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> SetPlayerActive([FromQuery]bool isPlaying)
    {
        try
        {
            var idPlayer = TokenUtility.GetIdPlayer(HttpContext.User);
            await _playerPlayingService.SetPlayerActive(idPlayer, isPlaying);
            return Ok();
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
}