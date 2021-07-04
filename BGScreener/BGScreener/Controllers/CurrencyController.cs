using System;
using BGScreener.DbModels;
using BGScreener.Model;
using BGScreener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BGScreener.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
        }

        [HttpGet("get")]
        public IActionResult Get()
            => Json(_currencyService.Get());

        [HttpGet("get/{id}")]
        public IActionResult Find(Guid id)
            => Json(_currencyService.Find(id));

        [HttpPost("add")]
        public IActionResult Insert([FromBody] Currency currency)
            => Json(_currencyService.Insert(currency));

        [HttpPost("update")]
        public IActionResult Update([FromBody] CurrencyDTO currency)
            => Json(_currencyService.Update(currency));

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] CurrencyDTO currency)
            => Json(_currencyService.Delete(currency));
    }
}
