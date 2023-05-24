using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller;
using TransportTicketing.Model;
using static System.Collections.Specialized.BitVector32;

namespace TransportTicketing.src.Controller
{
    public class TransportFileReader
    {
        public List<TransportClient> ReadTransportsFromCSV(string filePath, List<Station> stations)
        {
            List<TransportClient> transports = new List<TransportClient>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        if (data.Length >= 2)
                        {
                            string transportName = data[0];
                            string[] stationNames = data[1..];

                            TransportFactory transport = new TransportFactory();
                            TransportClient transportMode = new TransportClient(transport, transportName);

                            foreach (string stationName in stationNames)
                            {
                                Station station = stations.Find(stationName);
                                
                                if (station != null)
                                {
                                    transportMode.AddStation(station);
                                }
                            }
                            transports.Add(transportMode);
                        }
                    }
                }

                Console.WriteLine("Transports successfully read from the CSV file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the CSV file: " + ex.Message);
            }

            return transports;
        }
    }
}
