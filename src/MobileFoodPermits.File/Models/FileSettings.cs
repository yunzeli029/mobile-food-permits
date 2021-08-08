using System.IO;

namespace MobileFoodPermits.File.Models
{

    public class FileSettings
    {
        public string BasePath { get; set; }

        public string FileName { get; set; }

        public string GetFilePath()
            => Path.Combine(BasePath, FileName);
    }
}
