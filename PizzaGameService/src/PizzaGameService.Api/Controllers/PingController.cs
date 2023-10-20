using Microsoft.AspNetCore.Mvc;

namespace PizzaGameService.Api.Controllers;

[Route("api")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return Ok("pong");
    }
}