using System;
using MFU_BGCrawler.DbModels;
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

        [HttpGet("get")]
        public IActionResult Get()
            => Json(_storeService.Get());

        [HttpGet("get/{id}")]
        public IActionResult Find(Guid id)
            => Json(_storeService.Find(id));

        [HttpPost("add")]
        public IActionResult Insert([FromBody] Store store)
            => Json(_storeService.Insert(store));

        [HttpPost("update")]
        public IActionResult Update([FromBody] StoreDTO currency)
            => Json(_storeService.Update(currency));

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] StoreDTO currency)
            => Json(_storeService.Delete(currency));
    }
}