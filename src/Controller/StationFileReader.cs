using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
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
                            string stationName = data[0];
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
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the CSV file: " + ex.Message);
            }

            return Stations;
        }
    }
}
