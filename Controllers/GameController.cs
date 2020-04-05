using System.Collections.Generic;
using System.Text.Json;
using JustOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpPost]
        public Game StartGame([FromBody] string players)
        {
            var parsedPlayers = JsonSerializer.Deserialize<List<Player>>(players);
            return new Game(parsedPlayers);
        }
    }
}