using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller;
using TransportTicketing.Model;
using static System.Collections.Specialized.BitVector32;

namespace TransportTicketing.src.Controller
{
    public class TransportFileReader
    {
        private readonly string _fileName;
        private readonly List<Station> _stations;

        public TransportFileReader(string fileName, List<Station> stations)
        {
            _fileName = fileName;
            _stations = stations;
        }

        public List<TransportClient> ReadTransportsFromCSV()
        {
            List<TransportClient> transports = new List<TransportClient>();

            try
            {
                using (StreamReader reader = new StreamReader(_fileName))
                {
                    string? line;
                    TransportFactory transport;
                    TransportClient transportMode;
                    Station currentStation;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        if (data.Length >= 2)
                        {
                            string transportName = data[0];
                            string[] stationNames = data[1..];

                            transport = new TransportFactory(transportName);
                            transportMode = new TransportClient(transport);

                            foreach (string stationName in stationNames)
                            {
                                currentStation = new(stationName);

                                if (_stations.Contains(currentStation))
                                {
                                    transportMode.AddStation(currentStation);
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
