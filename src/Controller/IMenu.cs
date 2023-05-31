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
    public interface IMenu
    {
        public void Statement();

        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets);

        public void Options();
    }

    public class TransportOperation: IMenu
    {
        public void Statement()
        {
            Console.WriteLine("Transport Operation");
        }

        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            string userString;
            int user = 1;
            do
            {
                Options();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                userString = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                user = Convert.ToInt32(userString);
                switch (user)
                {
                    case 1:
                        Console.WriteLine("1");
                        break;

                    case 2:
                        Console.WriteLine("2");
                        break;

                    case 3:
                        Console.WriteLine("3");
                        break;

                    case 4:
                        Console.WriteLine("4");
                        break;

                    default: 
                        throw new IOException("Entered number is out of range");
                }
            } while (user != 0);
        }

        public void Options()
        {
            Console.WriteLine("1)\t" + "2)\t" + "3)\t" + "4)\t" + "0)\t");
        }
    }

    public class PassengerOperation : IMenu
    {
        public void Statement()
        {
            Console.WriteLine("Passenger Operation");
        }

        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            string userString;
            int user = 1;
            do
            {
                Options();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                userString = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                user = Convert.ToInt32(userString);
                string id;

                switch (user)
                {
                    case 1:
                        Console.WriteLine("What Passengers Standing do you want to change please enter their id:");
                        id = Console.ReadLine();
                        Console.WriteLine("What do you want their standing to be:");
                        string standing = Console.ReadLine();
                        passengers[id].UpdatePassengerStanding(standing);
                         
                        break;

                    case 2:
                        Console.WriteLine("What passengers details do you want? please enter their id:");
                        id = Console.ReadLine();
                        passengers[id].PrintPassengerDetails();
                        break;

                    case 3:
                        Console.WriteLine("What passengers standing do you want? please enter their id:");
                        id = Console.ReadLine();
                        passengers[id].GetCurrentStanding();
                        break;

                    case 4:
                        Console.WriteLine("What passengers status do you want? please enter their id:");
                        id = Console.ReadLine();
                        passengers[id].GetCurrentStatus();
                        break;

                    case 5:
                        Console.WriteLine("5");
                        Console.Write("To create a new passenger please enter their id (This needs to be unique): ");
                        id = Console.ReadLine();
                        
                        if (passengers.ContainsKey(id))
                        {
                            throw new Exception($"passenger with id: {id} already exists");
                        }

                        Console.Write("Please enter thier name: ");
                        string name = Console.ReadLine();

                        Console.Write("Please enter thier biller code: ");
                        int billerCode = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Please enter thier date of birth (DD/MM/YYYY): ");
                        string dob = Console.ReadLine();

                        PassengerController passenger = new PassengerController(id, name, billerCode, dob);
                        passengers.Add(id, passenger);
                        break;

                    default:
                        throw new IOException("Entered number is out of range");
                }
            } while (user != 0);
        }

        public void Options()
        {
            Console.WriteLine("\t1)\tChange Passenger Standing\n" + "\t2)\tPrint Passenger Details\n" + "\t3)\tGet Current Standing\n" + "\t4)\tGet Current Status\n" + "\t5)\tCreate a New Passenger\n" + "\t0)\tExit\n");
        }
    }

    public class Quit : IMenu
    {
        public void Statement()
        {
            Console.WriteLine("Exiting...");
        }

        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            Environment.Exit(0);
        }

        public void Options()
        {
            Console.WriteLine("");
        }
    }
}
