using System;
using BGScreener.DbModels;
using BGScreener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BGScreener.Controllers
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

        [HttpPost("add")] public IActionResult Insert([FromBody] ExchangeRateDTO exchangeRate) => Json(_exchangeRateService.Insert(exchangeRate));
    }
}
