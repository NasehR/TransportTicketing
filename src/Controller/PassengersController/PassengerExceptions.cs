using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing.Controller.PassengersController
{
    public class PassengerExceptions : Exception
    {
        public PassengerExceptions() : base()
        {
        }

        public PassengerExceptions(string? message) : base(message)
        {
        }

        public PassengerExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
