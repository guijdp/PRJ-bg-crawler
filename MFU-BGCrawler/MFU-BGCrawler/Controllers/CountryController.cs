using System;
using MFU_BGCrawler.DbModels;
using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
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
        public IActionResult Update([FromBody] DbcCountry country)
            => Json(_countryService.Update(country));

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] DbcCountry country)
            => Json(_countryService.Delete(country));
    }
}
