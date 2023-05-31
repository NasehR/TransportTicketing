using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TransportTicketing.View;

namespace TransportTicketing.View.FileReading
{
    /// <summary>
    /// This class is responsible for reading stations from a CSV file.
    /// </summary>
    public class StationFileReader
    {
        private readonly string _fileName;
        private readonly ErrorLogger _logger;

        /// <summary>
        /// Initializes a new instance of the StationFileReader class.
        /// </summary>
        /// <param name="fileName">The name of the CSV file to read from</param>
        /// <param name="logger">The error logger used for logging exceptions</param>
        public StationFileReader(string fileName, ErrorLogger logger)
        {
            _fileName = fileName;
            _logger = logger;
        }

        /// <summary>
        /// Reads stations from the CSV file and returns a list of Station objects.
        /// </summary>
        /// <returns>A list of Station objects</returns>
        public List<Station> ReadStationsFromCSV()
        {
            List<Station> Stations = new();

            try
            {
                using (StreamReader reader = new(_fileName))
                {
                    string? line;
                    Station station;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        foreach (var item in data)
                        {
                            string stationName = item.Trim();
                            station = new(stationName);

                            if (!Stations.Contains(station))
                            {
                                Stations.Add(station);
                            }
                        }
                    }
                }

                _logger.LogInfo("Stations successfully read from the CSV file.");
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex, $"File not found: {Path.GetFileName(_fileName)}");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"File name is null: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, $"Access denied: {Path.GetFileName(_fileName)}");
            }
            catch (IOException ex)
            {
                _logger.LogError(ex, $"I/O error occurred: {ex.Message}");
            }

            return Stations;
        }
    }
}