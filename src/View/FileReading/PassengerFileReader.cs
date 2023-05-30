﻿using System;
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
        private readonly ErrorLogger _logger;

        public PassengerFileReader(string fileName, ErrorLogger logger)
        {
            _fileName = fileName;
            _logger = logger;
        }

        public Dictionary<string, PassengerController> ReadPassengersFromJSON()
        {
            List<PassengerController> passengers;
            Dictionary<string, PassengerController> passengerDictionary = new();

            try
            {
                using (StreamReader reader = new(_fileName))
                {
                    string json = reader.ReadToEnd();

                    #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    passengerDictionary = JsonSerializer.Deserialize<Dictionary<string, PassengerController>>(json);
                    #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }

                _logger.LogInfo("Passengers successfully read from the JSON file.");
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex, $"File not found: {Path.GetFileName(_fileName)}");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, $"Invalid JSON format in file: {Path.GetFileName(_fileName)}");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, $"Not supported exception occurred: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, $"Argument null exception occurred: {ex.Message}");
            }

            #pragma warning disable CS8603 // Possible null reference return.
            return passengerDictionary;
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}