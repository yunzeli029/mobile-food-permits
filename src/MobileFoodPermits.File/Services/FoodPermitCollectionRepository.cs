using LazyCache;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.File.Services.Interfaces;
using MobileFoodPermits.Models.FoodPermitInfo;
using System;

namespace MobileFoodPermits.File.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class FoodPermitCollectionRepository : IFoodPermitCollectionRepository
    {
        private readonly IFileRepository _fileRepository;
        private readonly IAppCache _cache;
        private readonly FileSettings _fileSettings;

        public FoodPermitCollectionRepository(IFileRepository fileRepository, IAppCache cache, FileSettings fileSettings)
        {
            _fileRepository = fileRepository;
            _cache = cache;
            _fileSettings = fileSettings;
        }

        public FoodPermitCollection GetFoodPermitCollection()
        {
            var expiredTime = DateTime.Now.AddDays(1);
            return _cache.GetOrAdd(
                _fileSettings.FileName,
                () =>
                {
                    var filePath = _fileSettings.GetFilePath();
                    var infos = _fileRepository.Read<FoodPermit>(filePath);
                    return new FoodPermitCollection(DateTime.Now, infos);
                }, expiredTime);
        } 
    }
}
