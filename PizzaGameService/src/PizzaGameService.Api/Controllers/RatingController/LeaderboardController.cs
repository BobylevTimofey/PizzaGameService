using Microsoft.AspNetCore.Mvc;
using PizzaGameService.Data.PlayersRating.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.RatingService.Interfaces;

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
        [FromQuery] int countPlayers)
    {
        var leaderboard = await _ratingsService.GetLeaderboard(countPlayers);

        return Ok(leaderboard);
    }

    [Route("{idPlayer}")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PlayerLeaderboardResponse>> GetPlayerRating(int idPlayer)
    {
        try
        {
            var playerRating = await _ratingsService.GetPlayerRating(idPlayer);

            return Ok(playerRating);
        }
        catch (PlayerNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }
}