using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;

namespace TransportTicketing.Controller
{
    /// <summary>
    /// Interface representing a menu with common menu functionality.
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Displays a statement or message related to the menu.
        /// </summary>
        public void Statement();

        /// <summary>
        /// Runs the menu by performing operations using the provided dictionaries of transports, passengers, and tickets.
        /// </summary>
        /// <param name="transports">Dictionary of transport clients.</param>
        /// <param name="passengers">Dictionary of passenger controllers.</param>
        /// <param name="tickets">Dictionary of tickets.</param>
        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets);

        /// <summary>
        /// Displays the available options for the menu.
        /// </summary>
        public void Options();
    }

    /// <summary>
    /// Represents a class for performing transport operations and implementing the IMenu interface.
    /// </summary>
    public class TransportOperation : IMenu
    {
        /// <summary>
        /// Prints the statement for Transport Operation.
        /// </summary>
        public void Statement()
        {
            Console.WriteLine("Transport Operation");
        }

        /// <summary>
        /// Runs the transport operation menu.
        /// </summary>
        /// <param name="transports">Dictionary of transport clients.</param>
        /// <param name="passengers">Dictionary of passenger controllers.</param>
        /// <param name="tickets">Dictionary of tickets.</param>
        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            string userString;
            int user;
            do
            {
                Options();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                userString = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                user = Convert.ToInt32(userString);
                string transportName;
                switch (user)
                {
                    case 0:
                        user = 0;
                        break;

                    case 1:
                        Console.Write("Name of the transport of whose number of stations you want: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        transportName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                        Console.WriteLine($"Transport {transportName} has {transports[transportName].GetNumberOfStations()} stations in its route.");
#pragma warning restore CS8604 // Possible null reference argument.
                        break;

                    case 2:
                        Console.Write("Name of the transport of whose number of passengers you want: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        transportName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                        Console.WriteLine($"Transport {transportName} has {transports[transportName].GetCurrentPassengers()} passengers in it currently.");
#pragma warning restore CS8604 // Possible null reference argument.
                        break;

                    case 3:
                        Console.Write("Name of the transport which is getting a new station added to its route: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        transportName = Console.ReadLine();
                        Console.Write("Name of the station: ");
                        string stationName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                        Station station = new(stationName);
                        transports[transportName].AddStation(station);
#pragma warning restore CS8604 // Possible null reference argument.
                        break;

                    case 4:
                        Console.Write("Name of the transport which you are updating the status of: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        transportName = Console.ReadLine();
                        Console.Write("What is the new status of the transport: ");
                        string newStatus = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                        transports[transportName].UpdateTransportStatus(newStatus);
#pragma warning restore CS8604 // Possible null reference argument.
                        break;

                    case 5:
                        Console.Write("To get the current passenger what is the transport name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        transportName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
                        List<PassengerController> currentPassengers = transports[transportName].GetCurrentPassengers();
#pragma warning restore CS8604 // Possible null reference argument.

                        foreach (var passenger in currentPassengers)
                        {
                            passenger.PrintPassengerDetails();
                        }
                        break;

                    default:
                        throw new IOException("Entered number is out of range");
                }
            } while (user != 0);
        }

        /// <summary>
        /// Prints the available options for the transport operation.
        /// </summary>
        public void Options()
        {
            Console.WriteLine("\t1)\tGet Number of Stations\n\t2)\tGet Number of Passengers \n\t3)\tAdd a Station\n\t4)\tUpdate Transport Status\n\t5)\tGet Current Passengers\n\t0)\tExit\n");
        }
    }

    /// <summary>
    /// This class represents the passenger operations menu.
    /// </summary>
    public class PassengerOperation : IMenu
    {
        /// <summary>
        /// Displays the statement for the passenger operation menu.
        /// </summary>
        public void Statement()
        {
            Console.WriteLine("Passenger Operation");
        }

        /// <summary>
        /// Runs the passenger operation menu.
        /// </summary>
        /// <param name="transports">Dictionary of transport clients.</param>
        /// <param name="passengers">Dictionary of passenger controllers.</param>
        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            string userString;
            int user;
            do
            {
                Options();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                userString = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                user = Convert.ToInt32(userString);
                string? id, transportName;

                switch (user)
                {
                    case 0:
                        user = 0;
                        break;

                    case 1:
                        Console.WriteLine("What Passengers Standing do you want to change please enter their id:");
                        id = Console.ReadLine();
                        Console.WriteLine("What do you want their standing to be:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        string standing = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                        passengers[id!].UpdatePassengerStanding(standing!);
                        break;

                    case 2:
                        Console.WriteLine("What passengers details do you want? please enter their id:");
                        id = Console.ReadLine();
                        passengers[id!].PrintPassengerDetails();
                        break;

                    case 3:
                        Console.Write("What is the passenger id who is boarding: ");
                        id = Console.ReadLine();
                        Console.Write("What transport are they boarding: ");
                        transportName = Console.ReadLine();
                        int ticketNumber = tickets.Count + 1;
                        passengers[id!].Boarding(ticketNumber, transports[transportName!]);
                        break;

                    case 4:
                        Console.Write("What is the passenger id who is leaving: ");
                        id = Console.ReadLine();
                        Console.Write("What transport are they leaving: ");
                        transportName = Console.ReadLine();
                        passengers[id!].Leaving(transports[transportName!]);
                        break;

                    case 5:
                        Console.WriteLine("5");
                        Console.Write("To create a new passenger please enter their id (This needs to be unique): ");
                        id = Console.ReadLine();

                        if (passengers.ContainsKey(id!))
                        {
                            throw new Exception($"passenger with id: {id} already exists");
                        }

                        Console.Write("Please enter their name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        string name = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                        Console.Write("Please enter their biller code: ");
                        int billerCode = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Please enter their date of birth (DD/MM/YYYY): ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        string dob = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                        PassengerController passenger = new(id!, name!, billerCode, dob!);
                        passengers.Add(id!, passenger);
                        break;

                    default:
                        throw new IOException("Entered number is out of range");
                }
            } while (user != 0);
        }

        /// <summary>
        /// Displays the options for the passenger operation menu.
        /// </summary>

        public void Options()
        {
            Console.WriteLine("\t1)\tChange Passenger Standing\n\t2)\tPrint Passenger Details\n\t3)\tBoard a Transport\n\t4)\tLeave a Transport\n\t5)\tCreate a New Passenger\n\t0)\tExit\n");
        }
    }

    /// <summary>
    /// Represents the Quit class which implements the IMenu interface.
    /// </summary>
    public class Quit : IMenu
    {
        /// <summary>
        /// Prints the statement "Exiting..." to the console.
        /// </summary>
        public void Statement()
        {
            Console.WriteLine("Exiting...");
        }

        /// <summary>
        /// Exits the program by calling the Environment.Exit method with code 0.
        /// </summary>
        /// <param name="transports">A dictionary of transport clients.</param>
        /// <param name="passengers">A dictionary of passenger controllers.</param>
        /// <param name="tickets">A dictionary of tickets.</param>
        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints an empty line to the console.
        /// </summary>
        public void Options()
        {
            Console.WriteLine("");
        }
    }
}
