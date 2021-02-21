using System;
using System.Linq;
using System.Threading.Tasks;
using MFU_BGCrawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/country")]
    public class CountryController : Controller
    {
        private BGSniperContext db = new BGSniperContext();

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var countries = db.Country.Select(c => new { c.Id, c.CountryName, c.Currency, stores = c.Stores}).ToList();
                return Ok(countries);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}