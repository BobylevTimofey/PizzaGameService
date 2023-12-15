using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGameService.Data.PlayerData.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerGameDataService.Interfaces;
using PizzaGameService.Service.TokensService.Utilities;

namespace PizzaGameService.Api.Controllers.PlayerDataController;

[Route("api/v1/player/data")]
[ApiController]
public class PlayerDataController : ControllerBase
{
    private readonly IPlayerDataService _playerDataService;

    public PlayerDataController(IPlayerDataService playerDataService)
    {
        _playerDataService = playerDataService;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<PlayerGameData>> GetPlayerData()
    {
        try
        {
            var idPlayer = TokenUtility.GetIdPlayer(HttpContext.User);

            var playerData = await _playerDataService.GetPlayerData(idPlayer);
            return Ok(playerData);
        }
        catch (PlayerNotVerifyException exception)
        {
            return Unauthorized(exception.Message);
        }
        catch (PlayerNotFoundException)
        {
            return NotFound(string.Empty);
        }
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> SetPlayerData(PlayerGameData request)
    {
        try
        {
            var idPlayer = TokenUtility.GetIdPlayer(HttpContext.User);

            await _playerDataService.UpdatePlayerData(idPlayer, request);
            return Ok();
        }
        catch (PlayerNotVerifyException exception)
        {
            return Unauthorized(exception.Message);
        }
        catch (PlayerNotFoundException)
        {
            return NotFound(string.Empty);
        }
    }
}