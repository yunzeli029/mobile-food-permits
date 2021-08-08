using System.Collections.Generic;

namespace MobileFoodPermits.File.Services.Interfaces
{
    public interface IFileRepository
    {
        public IEnumerable<T> Read<T>(string filePath);
    }
}
