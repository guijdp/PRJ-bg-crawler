using System;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/[controller]")]
    public class ExchangeRateController : Controller
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService ?? throw new ArgumentNullException(nameof(exchangeRateService));
        }

        [HttpGet("get")] public IActionResult Get() => Json(_exchangeRateService.Get());

        [HttpPost("add")] public IActionResult Insert([FromBody] DbcExchangeRate exchangeRate) => Json(_exchangeRateService.Insert(exchangeRate));
    }
}
