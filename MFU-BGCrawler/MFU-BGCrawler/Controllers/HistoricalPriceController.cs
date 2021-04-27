using System;
using MFU_BGCrawler.Model.Dbc;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
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

        [HttpPost("add")] public IActionResult Insert([FromBody] DbcHistoricalPrice historicalPrice) => Json(_historicalPriceService.Insert(historicalPrice));
    }
}
