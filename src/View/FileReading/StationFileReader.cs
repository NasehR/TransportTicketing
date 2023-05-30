using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TransportTicketing.View;

namespace TransportTicketing.View.FileReading
{
    public class StationFileReader
    {
        private readonly string _fileName;
        private readonly ErrorLogger _logger;

        public StationFileReader(string fileName, ErrorLogger logger)
        {
            _fileName = fileName;
            _logger = logger;
        }

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

                        if (data.Length >= 1)
                        {
                            string stationName = data[0].Trim();
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
