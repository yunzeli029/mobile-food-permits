using Microsoft.AspNetCore.Mvc;
using MobileFoodPermits.Models.FoodPermitInfo;

namespace MobileFoodPermits.Service.Controllers
{
    [Route("api/food-permits-shortname")]
    [ApiController]
    public class FoodPermitsShortNameController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var shortNames = ShortNameMappings.ShortNameToPropertyMapping.Keys;
            return Ok(shortNames);
        }
    }
}
