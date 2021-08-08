using Microsoft.AspNetCore.Mvc;
using MobileFoodPermits.File.Services.Interfaces;
using MobileFoodPermits.Service.Extensions;
using MobileFoodPermits.Service.Models;

namespace MobileFoodPermits.Service.Controllers
{
    [Route("api/food-permits")]
    [ApiController]
    public class FoodPermitsController : ControllerBase
    {
        private readonly IFoodPermitsProvider _foodPermitsProvider;

        public FoodPermitsController(IFoodPermitsProvider foodPermitsProvider)
        {
            _foodPermitsProvider = foodPermitsProvider;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var permits = _foodPermitsProvider.GetAll();
            return Ok(permits);
        }

        [HttpPost]
        [Route("search")]
        public IActionResult GetFilteredResult(FilteredRequestDto filteredRequestDto)
        {
            var filter = filteredRequestDto.Filter.Convert();
            var permits = _foodPermitsProvider.GetFilteredPermits(filter);

            return Ok(permits);
        }
    }
}
