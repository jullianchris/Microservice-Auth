using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var account = HttpContext.Request.Headers["Account"];
            return new string[] { "Inventory", "Account - " + account };
        }
    }
}
