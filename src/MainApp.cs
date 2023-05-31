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
#pragma warning disable CS0168 // Variable is declared but never used
            Dictionary<string, Ticket> Tickets;
#pragma warning restore CS0168 // Variable is declared but never used
            Dictionary<string, TransportClient> Transports;
            List<Station> Stations;
            ErrorLogger Logger = new(ErrorFilePath);

            if (args.Length == 2)
            {
                try
                {
                    stationFileName = Path.GetFullPath(args[0]);
                    transportFileName = Path.GetFullPath(args[1]);

                    StationFileReader sFR = new(stationFileName, Logger);
                    Stations = sFR.ReadStationsFromCSV();

                    TransportFileReader tFR = new(transportFileName, Stations, Logger);
                    Transports = tFR.ReadTransportsFromCSV();
                }
                catch (PassengerExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (TransportExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (PassengerStateExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (TransportStateExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
            }
            else if (args.Length == 3)
            {
                try
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
                }
                catch (PassengerExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (TransportExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (PassengerStateExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (TransportStateExceptions ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, $"{ex.Message}");
                }
            }
        }
    }
}