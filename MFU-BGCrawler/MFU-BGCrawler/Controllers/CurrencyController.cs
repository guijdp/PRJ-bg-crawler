using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService countryService)
        {
            _currencyService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet("get")] public IActionResult Get() => Json(_currencyService.Get());
        [HttpGet("get/{id}")] public IActionResult Find(Guid id) => Json(_currencyService.Find(id));

        [HttpPost("add")] public IActionResult Insert([FromBody] Currency currency) => Json(_currencyService.Insert(currency));
    }
}
