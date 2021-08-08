using MobileFoodPermits.Models.FoodPermitInfo;

namespace MobileFoodPermits.File.Services.Interfaces
{
    public interface IFoodPermitCollectionRepository
    {
        FoodPermitCollection GetFoodPermitCollection();
    }
}
