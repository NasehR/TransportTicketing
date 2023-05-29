using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TransportTicketing.Controller.PassengersController;

namespace TransportTicketing.View
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
            Dictionary<string, PassengerController> passengers = new Dictionary<string, PassengerController>();
            //LinkedList<PassengerController>? passengerList;

            try
            {
                using (StreamReader reader = new StreamReader(_fileName))
                {
                    string json = reader.ReadToEnd();
                    Console.WriteLine(json);

                    //passengerList = JsonSerializer.Deserialize<LinkedList<PassengerController>>(json);

                    /*
                    foreach (var passenger in json)
                    {
                        Console.WriteLine(passenger);
                    }
                    */
                    // create a passengercontroller
                    /*
                    const string id = "SR070148614";
                    const string name = "Naseh Rizvi";
                    const int billerCode = 241513;
                    const string dob = "06/05/2002";

                    PassengerController passenger = new PassengerController(id, name, billerCode, dob);
                    */
                }

                Console.WriteLine("Passengers successfully read from the JSON file.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found: " + _fileName);
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON format in file: " + _fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the JSON file: " + ex.Message);
            }

            return passengers;
        }
    }
}