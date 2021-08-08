using CsvHelper;
using CsvHelper.Configuration;
using MobileFoodPermits.File.Services.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MobileFoodPermits.File.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class FileRepository : IFileRepository
    {
        public IEnumerable<T> Read<T>(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null,
                IgnoreBlankLines = true,
            };

            // TODO: Handle rows with Invalid values
            using (var fileStream = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(fileStream, config))
                {
                    var records = csv.GetRecords<T>();
                    return records.ToList();
                }              
            }
        }
    }
}
