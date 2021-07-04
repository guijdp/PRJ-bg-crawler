using System;
using BGScreener.DbModels;
using BGScreener.Model;
using BGScreener.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BGScreener.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet("get")]
        public IActionResult Get()
            => Json(_countryService.Get());
        [HttpGet("get/{id}")]

        public IActionResult Find(Guid id)
            => Json(_countryService.Find(id));

        [HttpPost("add")]
        public IActionResult Insert([FromBody] Country country)
            => Json(_countryService.Insert(country));

        [HttpPost("update")]
        public IActionResult Update([FromBody] CountryDTO country)
            => Json(_countryService.Update(country));

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] CountryDTO country)
            => Json(_countryService.Delete(country));
    }
}
