using System;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BGScreener.Controllers
{
    [Route("api/[controller]")]
    public class HistoricalPriceController : Controller
    {
        private readonly IHistoricalPriceService _historicalPriceService;

        public HistoricalPriceController(IHistoricalPriceService historicalPriceService)
        {
            _historicalPriceService = historicalPriceService ?? throw new ArgumentNullException(nameof(historicalPriceService));
        }

        [HttpGet("get")] public IActionResult Get() => Json(_historicalPriceService.Get());

        [HttpPost("add")] public IActionResult Insert([FromBody] HistoricalPriceDTO historicalPrice) => Json(_historicalPriceService.Insert(historicalPrice));
    }
}
