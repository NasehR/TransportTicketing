using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;
using static System.Collections.Specialized.BitVector32;

namespace TransportTicketing.View.FileReading
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

        public Dictionary<string, TransportClient> ReadTransportsFromCSV()
        {
            Dictionary<string, TransportClient> transports = new Dictionary<string, TransportClient>();

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
                            string nameOfTransport = data[0];
                            string transportName = data[1].Trim();
                            string[] stationNames = data[2..];

                            transport = new TransportFactory(transportName);
                            transportMode = new TransportClient(transport);

                            foreach (string stationName in stationNames)
                            {
                                currentStation = new(stationName.Trim());

                                if (_stations.Contains(currentStation))
                                {
                                    transportMode.AddStation(currentStation);
                                }
                            }

                            transports.Add(nameOfTransport, transportMode);
                        }
                    }
                }

                Console.WriteLine("Transports successfully read from the CSV file.");
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

            return transports;
        }
    }
}
