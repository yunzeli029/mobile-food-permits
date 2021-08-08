using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using System.Collections.Generic;

namespace MobileFoodPermits.File.Services.Interfaces
{
    public interface IFoodPermitsProvider
    {
        IEnumerable<FoodPermit> GetAll();

        IEnumerable<FoodPermit> GetFilteredPermits(IItemComparisonFilter filter);
    }
}
