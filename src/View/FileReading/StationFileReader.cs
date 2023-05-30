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

        public StationFileReader(string fileName)
        {
            _fileName = fileName;
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

                Console.WriteLine("Stations successfully read from the CSV file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {Path.GetFileName(_fileName)}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("File name is null: " + ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Access denied: {Path.GetFileName(_fileName)}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("I/O error occurred: " + ex.Message);
            }

            return Stations;
        }
    }
}
