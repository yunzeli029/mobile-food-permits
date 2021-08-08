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
    /// A file repository to Read a csv file from provided path
    /// </summary>
    public class CSVFileRepository : IFileRepository
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

            try
            {
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
            catch (FileNotFoundException e)
            {
                throw e;
            }
            catch (CsvHelperException)
            {
                var message = $"Unable to load file data from {filePath};" +
                                $"This probably indicates that the file is not CSV file or data formats are incorrect.";

                throw new InvalidDataException(message);
            }
        }
    }
}
