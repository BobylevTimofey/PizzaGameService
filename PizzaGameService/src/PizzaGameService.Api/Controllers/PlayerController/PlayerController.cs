﻿using Microsoft.AspNetCore.Mvc;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.PlayerService.Requests;

namespace PizzaGameService.Api.Controllers.PlayerController;

[Route("api/v1/player")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerAuthorizationService _authorizationService;

    public PlayerController(IPlayerAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost]
    [Route("registration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<int>> RegisterPlayer(PlayerRegistrationRequest request)
    {
        var idPlayer = await _authorizationService.SignUp(request);

        return Created(string.Empty, idPlayer);
    }

    [HttpPost]
    [Route("authorization")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<int>> AuthorizePlayer(PlayerAuthorizationRequest request)
    {
        var idPlayer = await _authorizationService.SingIn(request);

        return Ok(idPlayer);
    }
}