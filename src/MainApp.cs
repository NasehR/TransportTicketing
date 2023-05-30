using System;
using System.Collections.Generic;
using TransportTicketing.View;
using Microsoft.VisualBasic.FileIO;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View.FileReading;

namespace TransportTicketing
{
    public static class MainApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            Console.WriteLine("MainApp");

            Dictionary<string, PassengerController> Passengers;
            Dictionary<string, Ticket> Tickets;
            Dictionary<string, TransportClient> Transports;
            List<Station> Stations;

            if (args.Length == 2)
            {
                try
                {
                    string stationFileName = Path.GetFullPath(args[0]);
                    string transportFileName = Path.GetFullPath(args[1]);

                    StationFileReader sFR = new StationFileReader(stationFileName);
                    Stations = sFR.ReadStationsFromCSV();

                    TransportFileReader tFR = new TransportFileReader(transportFileName, Stations);
                    Transports = tFR.ReadTransportsFromCSV();
                }
                catch (PassengerExceptions ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            else if (args.Length == 3)
            {
                try
                {
                    string stationFileName = Path.GetFullPath(args[0]);
                    string transportFileName = Path.GetFullPath(args[1]);
                    string passengerFileName = Path.GetFullPath(args[2]);

                    StationFileReader sFR = new StationFileReader(stationFileName);
                    Stations = sFR.ReadStationsFromCSV();

                    TransportFileReader tFR = new TransportFileReader(transportFileName, Stations);
                    Transports = tFR.ReadTransportsFromCSV();

                    PassengerFileReader pFR = new PassengerFileReader(passengerFileName);
                    Passengers = pFR.ReadPassengersFromJSON();

                    Console.WriteLine(Passengers["003"].GetCurrentStanding());
                    Passengers["003"].UpdatePassengerStanding("canced");
                    Console.WriteLine(Passengers["003"].GetCurrentStanding());
                }
                catch (PassengerExceptions ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}