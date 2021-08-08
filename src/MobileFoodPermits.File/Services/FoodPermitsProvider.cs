using MobileFoodPermits.Extensions;
using MobileFoodPermits.File.Services.Interfaces;
using MobileFoodPermits.Models.Filters.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using System.Collections.Generic;

namespace MobileFoodPermits.File.Services
{
    public class FoodPermitsProvider : IFoodPermitsProvider
    {
        private readonly IFoodPermitCollectionRepository _foodPermitCollectionRepository;

        public FoodPermitsProvider(IFoodPermitCollectionRepository foodPermitCollectionRepository)
        {
            _foodPermitCollectionRepository = foodPermitCollectionRepository;
        }

        public IEnumerable<FoodPermit> GetAll()
        {
            return _foodPermitCollectionRepository.GetFoodPermitCollection().FoodPermits;
        }

        public IEnumerable<FoodPermit> GetFilteredPermits(IItemComparisonFilter filter)
        {
            return _foodPermitCollectionRepository.GetFoodPermitCollection().FilterItem(filter);
        }
    }
}
