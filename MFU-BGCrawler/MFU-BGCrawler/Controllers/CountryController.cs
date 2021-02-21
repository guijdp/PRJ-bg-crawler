using MFU_BGCrawler.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/country")]
    public class CountryController : Controller
    {
        private readonly BGSniperContext _dbContext;
        private readonly ILogger _logger;
        public CountryController(BGSniperContext dbContext, ILogger logger)
        {
            
        }
    }
}