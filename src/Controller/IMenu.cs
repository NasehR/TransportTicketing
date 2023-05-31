using System;
using System.Collections.Generic;
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
    }

    public class TransportOperation: IMenu
    {
        public void Statement()
        {
            Console.WriteLine("Transport Operation");
        }

        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            Console.WriteLine("Transport Operation are to be done here.");
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
            Console.WriteLine("Passenger Operation are to be done here.");
        }
    }

    public class Quit : IMenu
    {
        public void Statement()
        {
            Console.WriteLine("Exitting...");
        }

        public void Run(Dictionary<string, TransportClient> transports, Dictionary<string, PassengerController> passengers, Dictionary<string, Ticket> tickets)
        {
            Environment.Exit(0);
        }
    }
}
