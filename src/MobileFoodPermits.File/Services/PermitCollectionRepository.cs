using LazyCache;
using MobileFoodPermits.File.Models;
using MobileFoodPermits.File.Services.Interfaces;
using System;
using System.Linq;

namespace MobileFoodPermits.File.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class PermitCollectionRepository : IPermitCollectionRepository
    {
        private readonly IFileRepository _fileRepository;
        private readonly IAppCache _cache;
        private readonly FileSettings _fileSettings;

        public PermitCollectionRepository(IFileRepository fileRepository, IAppCache cache, FileSettings fileSettings)
        {
            _fileRepository = fileRepository;
            _cache = cache;
            _fileSettings = fileSettings;
        }

        public PermitsInfoCollection Get()
        {
            return _cache.GetOrAdd(
                _fileSettings.FileName,
                () =>
                {
                    var filePath = _fileSettings.GetFilePath();
                    var infos = _fileRepository.Read<PermitInfo>(filePath).ToList();
                    return new PermitsInfoCollection(DateTime.Now, infos);
                });
        }
    }
}
