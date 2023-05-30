﻿using System;
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
            try
            {
                Console.WriteLine(args.Length);
                Console.WriteLine("MainApp");

                Dictionary<string, PassengerController> Passengers = new Dictionary<string, PassengerController>();
                Dictionary<string, Ticket> Tickets = new Dictionary<string, Ticket>();
                Dictionary<string, TransportClient> Transports = new Dictionary<string, TransportClient>();
                List<Station> Stations = new List<Station>();

                if (args.Length == 2)
                {
                    string stationFileName = Path.GetFullPath(args[0]);
                    string transportFileName = Path.GetFullPath(args[1]);

                    StationFileReader sFR = new StationFileReader(stationFileName);
                    Stations = sFR.ReadStationsFromCSV();

                    TransportFileReader tFR = new TransportFileReader(transportFileName, Stations);
                    Transports = tFR.ReadTransportsFromCSV();

                    /*
                    const string id = "SR070148614";
                    const string name = "Naseh Rizvi";
                    const int billerCode = 241513;
                    const string dob = "06/05/2002";

                    PassengerController passenger = new PassengerController(id, name, billerCode, dob);
                    Passengers.Add(id, passenger);
                    Console.WriteLine("Passenger Added to Dictionary\n");

                    Console.Write("Passenger Status: ");
                    Console.WriteLine(Passengers["SR070148614"].GetCurrentStatus() + "\n");

                    Console.WriteLine("Passenger is boarding bus 999");
                    Passengers["SR070148614"].Boarding(1, Transports["999"]);
                    Console.WriteLine("Passenger is on bus 999");
                    Console.WriteLine(Passengers["SR070148614"].GetCurrentStatus() + "\n");

                    Console.WriteLine("Passenger is leaving bus 999");
                    Passengers["SR070148614"].Leaving(Transports["999"]);
                    Console.WriteLine(Passengers["SR070148614"].GetCurrentStatus());

                    Passengers["SR070148614"].Boarding(2, Transports["999"]);
                    Console.WriteLine("Passenger is off bus 999");
                    Console.WriteLine(Passengers["SR070148614"].GetCurrentStatus() + "\n");

                    int num = Transports["999"].GetNumberOfPassengers();

                    Console.WriteLine($"Current number of passengers: {num}");

                    foreach (var p in Transports["999"].GetCurrentPassengers())
                    {
                        p.PrintPassengerDetails();
                    }
                    */
                }
                else if (args.Length == 3)
                {
                    string stationFileName = Path.GetFullPath(args[0]);
                    string transportFileName = Path.GetFullPath(args[1]);
                    string passengerFileName = Path.GetFullPath(args[2]);
                    List<PassengerController> PC = new List<PassengerController>();

                    StationFileReader sFR = new StationFileReader(stationFileName);
                    Stations = sFR.ReadStationsFromCSV();

                    TransportFileReader tFR = new TransportFileReader(transportFileName, Stations);
                    Transports = tFR.ReadTransportsFromCSV();

                    PassengerFileReader pFR = new PassengerFileReader(passengerFileName);
                    Passengers = pFR.ReadPassengersFromJSON();


                    Passengers["001"].PrintPassengerDetails();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}