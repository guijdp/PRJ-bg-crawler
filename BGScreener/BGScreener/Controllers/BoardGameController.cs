using System;
using BGScreener.DbModels;
using BGScreener.Model;
using BGScreener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BGScreener.Controllers
{
    [Route("api/[controller]")]
    public class BoardGameController : Controller
    {
        private readonly IBoardgameService _boardGameService;

        public BoardGameController(IBoardgameService boardGameService)
        {
            _boardGameService = boardGameService ?? throw new ArgumentNullException(nameof(boardGameService));
        }

        [HttpGet("get")]
        public IActionResult Get()
            => Json(_boardGameService.Get());

        [HttpGet("get/{id}")]
        public IActionResult Find(Guid id)
            => Json(_boardGameService.Find(id));

        [HttpPost("add")]
        public IActionResult Insert([FromBody] Boardgame boardGame)
            => Json(_boardGameService.Insert(boardGame));

        [HttpPost("update")]
        public IActionResult Update([FromBody] BoardgameDTO currency)
            => Json(_boardGameService.Update(currency));

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] BoardgameDTO currency)
            => Json(_boardGameService.Delete(currency));
    }
}
