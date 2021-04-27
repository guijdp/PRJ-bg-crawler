using System;
using MFU_BGCrawler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {

        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
        }

        [HttpGet("get")] public IActionResult Get() => Json(_storeService.Get());

        [HttpGet("get/{id}")] public IActionResult Find(int id) => Json(_storeService.Find(id));

        [HttpPost("add")] public IActionResult Insert([FromBody] Store store) => Json(_storeService.Insert(store));
    }
}