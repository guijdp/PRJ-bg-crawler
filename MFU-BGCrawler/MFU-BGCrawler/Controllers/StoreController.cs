using System;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/store")]
    public class StoreController : Controller
    {

        private readonly IStoreService _storeService;
        private readonly ILogger _logger;

        public StoreController(IStoreService storeService, ILogger logger)
        {
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Produces("application/json")]
        [HttpGet("list")]
        public IActionResult ListStores()
        {
            try
            {
                var stores = _storeService.GetStores();
                return Ok(stores);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("list/{name}")]
        public IActionResult FindStores(string name)
        {
            throw new NotImplementedException();
        }

        [Produces("application/json")]
        [HttpPost("insert")]
        public IActionResult InsertStores([FromBody] StoreModel store)
        {
            throw new NotImplementedException();
        }
    }
}