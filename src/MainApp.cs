using System;
using System.Collections.Generic;
using TransportTicketing.View;
using Microsoft.VisualBasic.FileIO;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View.FileReading;
using System.Globalization;
using TransportTicketing.Model.PassengerModel;
using TransportTicketing.Model.TransportModel;
using TransportTicketing.Controller;

namespace TransportTicketing
{
    public static class MainApp
    {
        public static void Main(string[] args)
        {
            const string ErrorFilePath = "ErrorLogs.txt";
            string stationFileName;
            string transportFileName;
            string passengerFileName;

            if (File.Exists(ErrorFilePath))
            {
                File.Delete(ErrorFilePath);
            }

            Dictionary<string, PassengerController> Passengers;
            Dictionary<string, TransportClient> Transports;
            List<Station> Stations;
            ErrorLogger Logger = new(ErrorFilePath);
            TransportTicketingApp app;
            UserInterface ui;

            if (args.Length == 2)
            {
                stationFileName = Path.GetFullPath(args[0]);
                transportFileName = Path.GetFullPath(args[1]);

                StationFileReader sFR = new(stationFileName, Logger);
                Stations = sFR.ReadStationsFromCSV();

                TransportFileReader tFR = new(transportFileName, Stations, Logger);
                Transports = tFR.ReadTransportsFromCSV();

                app = new TransportTicketingApp(Transports);
                ui = new UserInterface(app, Logger);

                ui.Menu();
            }
            else if (args.Length == 3)
            {
                stationFileName = Path.GetFullPath(args[0]);
                transportFileName = Path.GetFullPath(args[1]);
                passengerFileName = Path.GetFullPath(args[2]);

                StationFileReader sFR = new(stationFileName, Logger);
                Stations = sFR.ReadStationsFromCSV();

                TransportFileReader tFR = new(transportFileName, Stations, Logger);
                Transports = tFR.ReadTransportsFromCSV();

                PassengerFileReader pFR = new(passengerFileName, Logger);
                Passengers = pFR.ReadPassengersFromJSON();

                Console.WriteLine(Stations.Count);
                Console.WriteLine(Stations[0].Name);

                app = new TransportTicketingApp(Transports, Passengers);
                ui = new UserInterface(app, Logger);

                ui.Menu();
            }
            else
            {
                Console.WriteLine("Incorrect number of arguments were provided.");
            }
        }
    }
}