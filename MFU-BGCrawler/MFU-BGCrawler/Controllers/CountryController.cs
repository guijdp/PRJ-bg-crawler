using MFU_BGCrawler.Model;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("get")] public IActionResult Get() => Json(_countryService.Get());
        [HttpGet("get/{id}")] public IActionResult Find(Guid id) => Json(_countryService.Find(id));

        [HttpPost("add")] public IActionResult Insert([FromBody] Country country) => Json(_countryService.Insert(country));
    }
}
