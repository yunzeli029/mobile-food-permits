using MobileFoodPermits.File.Models;

namespace MobileFoodPermits.File.Services.Interfaces
{
    public interface IPermitCollectionRepository
    {
        PermitsInfoCollection Get();
    }
}
