using BattleShipsGameAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BattleShipsGameAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BattleShipsContoller : ControllerBase
{
  private readonly BattleShipsWarService _battleShipsWarService;

  public BattleShipsContoller()
  {
    _battleShipsWarService = new BattleShipsWarService();
  }

  [HttpPost]
  [Route("fire")]
  public IActionResult MakeMove([FromBody] FireRequest request)
  {
    var result = _battleShipsWarService.Fire(request.X, request.Y);
    return Ok(result);
  }

  [HttpGet]
  [Route("misileStatus")]
  public IActionResult GetBoardState()
  {
    return Ok(_battleShipsWarService.MisileStatus());
  }

  [HttpGet]
  [Route("resetGame")]
  public IActionResult ResetGame()
  {
    _battleShipsWarService.ResetGame();
    return Ok();
  }
}