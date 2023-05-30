using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Model.PassengerModel;

namespace TransportTicketing.View.FileReading
{
    public class PassengerFileReader
    {
        private readonly string _fileName;

        public PassengerFileReader(string fileName)
        {
            _fileName = fileName;
        }

        public Dictionary<string, PassengerController> ReadPassengersFromJSON()
        {
            List<PassengerController> passengers = new List<PassengerController>();
            Dictionary<string, PassengerController> passengerDictionary = new Dictionary<string, PassengerController>();

            try
            {
                using (StreamReader reader = new StreamReader(_fileName))
                {
                    string json = reader.ReadToEnd();

                    passengerDictionary = JsonSerializer.Deserialize<Dictionary<string, PassengerController>>(json);
                }

                Console.WriteLine("Passengers successfully read from the JSON file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {Path.GetFileName(_fileName)}");
            }
            catch (JsonException)
            {
                Console.WriteLine($"Invalid JSON format in file: {Path.GetFileName(_fileName)}");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Not supported exception occurred: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Argument null exception occurred: " + ex.Message);
                // Handle the ArgumentNullException
            }

            return passengerDictionary;
        }
    }
}