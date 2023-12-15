using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaGameService.Data.PlayersRating.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.RatingService.Interfaces;
using PizzaGameService.Service.TokensService.Utilities;

namespace PizzaGameService.Api.Controllers.RatingController;

[Route("api/v1/leaderboard")]
[ApiController]
public class LeaderboardController : ControllerBase
{
    private readonly IRatingsService _ratingsService;

    public LeaderboardController(IRatingsService ratingsService)
    {
        _ratingsService = ratingsService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<PlayerLeaderboardResponse>>> GetLeaderboard(
        [FromQuery] int countPlayers = 10)
    {
        var leaderboard = await _ratingsService.GetLeaderboard(countPlayers);

        return Ok(leaderboard);
    }

    [Route("player")]
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<PlayerLeaderboardResponse>> GetPlayerRating()
    {
        try
        {
            var idPlayer = TokenUtility.GetIdPlayer(HttpContext.User);

            var playerRating = await _ratingsService.GetPlayerRating(idPlayer);

            return Ok(playerRating);
        }
        catch (PlayerNotVerifyException exception)
        {
            return Unauthorized(exception.Message);
        }
        catch (PlayerNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }
}