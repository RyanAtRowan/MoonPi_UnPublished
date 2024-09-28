using CsvHelper; // External library to assist with CSV parsing
using Portfolio.Models; // Importing models used in the project, particularly the 'Scroll' class
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Portfolio.Services
{
    /// <summary>
    /// Service class to read scroll data from a CSV file and map it to a list of Scroll objects.
    /// </summary>
    public class CsvReaderService
    {
        /// <summary>
        /// Reads and parses scroll data from a CSV file.
        /// </summary>
        /// <param name="filePath">The file path of the CSV containing scroll data.</param>
        /// <returns>A list of Scroll objects populated from the CSV file.</returns>
        public List<Scroll> GetScrollsFromCsv(string filePath)
        {
            // Open the file at the given path for reading
            using (var reader = new StreamReader(filePath))
            // Initialize CsvReader with the StreamReader and set it to use invariant culture (language-neutral format)
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Register a class map for custom mapping between the CSV and the Scroll object
                csv.Context.RegisterClassMap<ScrollMap>();

                // Read and convert all CSV records into a list of Scroll objects
                var records = csv.GetRecords<Scroll>().ToList();

                // Return the list of Scroll objects
                return records;
            }
        }
    }
}
