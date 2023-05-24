using System;
using System.Collections.Generic;
using System.Linq;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class StationFileReader
    {
        public List<Station> ReadStationsFromCSV(string filePath)
        {
            List<Station> Stations = new List<Station>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        if (data.Length >= 1)
                        {
                            string stationName = data[0];
                            Station station = new Station(stationName);
                            
                            if (!(Stations.Contains(station)))
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
