﻿using System;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/[controller]")]
    public class BoardGameController : Controller
    {
        private readonly IBoardgameService _boardGameService;

        public BoardGameController(IBoardgameService boardGameService)
        {
            _boardGameService = boardGameService ?? throw new ArgumentNullException(nameof(boardGameService));
        }

        [HttpGet("get")] public IActionResult Get() => Json(_boardGameService.Get());
        [HttpGet("get/{id}")] public IActionResult Find(int id) => Json(_boardGameService.Find(id));

        [HttpPost("add")] public IActionResult Insert([FromBody] DbcBoardgame boardGame) => Json(_boardGameService.Insert(boardGame));
    }
}