using CsvHelper;
using Portfolio.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Portfolio.Services
{
    public class CsvReaderService
    {
        public List<Scroll> GetScrollsFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ScrollMap>();
                var records = csv.GetRecords<Scroll>().ToList();
                return records;
            }
        }
    }
}
