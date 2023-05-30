using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;

namespace TransportTicketing.View.FileReading
{
    public class TransportFileReader
    {
        private readonly string _fileName;
        private readonly List<Station> _stations;
        private readonly ErrorLogger _logger;

        public TransportFileReader(string fileName, List<Station> stations, ErrorLogger logger)
        {
            _fileName = fileName;
            _stations = stations;
            _logger = logger;
        }

        public Dictionary<string, TransportClient> ReadTransportsFromCSV()
        {
            Dictionary<string, TransportClient> transports = new();

            try
            {
                using (StreamReader reader = new(_fileName))
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

                _logger.LogInfo("Transports successfully read from the CSV file.");
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

            return transports;
        }
    }
}