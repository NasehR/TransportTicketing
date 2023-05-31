using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;

namespace TransportTicketing.View.FileReading
{
    /// <summary>
    /// The TransportFileReader class reads transports from a CSV file and creates a dictionary of TransportClient objects.
    /// </summary>
    public class TransportFileReader
    {
        private readonly string _fileName;
        private readonly List<Station> _stations;
        private readonly ErrorLogger _logger;

        /// <summary>
        /// Initializes a new instance of the TransportFileReader class with the specified file name, list of stations, and error logger.
        /// </summary>
        /// <param name="fileName">The name of the CSV file to be read.</param>
        /// <param name="stations">The list of stations.</param>
        /// <param name="logger">The error logger.</param>
        public TransportFileReader(string fileName, List<Station> stations, ErrorLogger logger)
        {
            _fileName = fileName;
            _stations = stations;
            _logger = logger;
        }

        /// <summary>
        /// Reads transports from the CSV file and returns a dictionary of TransportClient objects.
        /// </summary>
        /// <returns>A dictionary of TransportClient objects, where the key is the name of the transport.</returns>
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
                                Console.WriteLine(stationName.Trim());
                                currentStation = new(stationName);
                                transportMode.AddStation(currentStation);

                                if (_stations.Exists(s => s.Name == stationName))
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