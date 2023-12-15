using Microsoft.AspNetCore.Mvc;

namespace PizzaGameService.Api.Controllers;

[Route("api/v1")]
[ApiController]
public class PingController : ControllerBase
{
    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return Ok("pong");
    }
}