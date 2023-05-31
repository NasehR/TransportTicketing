using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing.Controller
{
    public interface IMenu
    {
        public void Statement();
        public void Run();
    }

    public class TransportOperation: IMenu
    {
        public void Statement()
        {
            Console.WriteLine("Transport Operation");
        }

        public void Run()
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

        public void Run()
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

        public void Run()
        {
            Environment.Exit(0);
        }
    }
}
