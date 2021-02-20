using System;
using System.Linq;
using System.Threading.Tasks;
using MFU_BGCrawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace MFU_BGCrawler.Controllers
{
    [Route("api/store")]
    public class StoreController : Controller
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var stores = db.Store.ToList();
                return Ok(stores);
            }
            catch()
            {
                return BadRequest();
            }
        }

    }
}