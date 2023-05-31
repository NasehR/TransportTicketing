using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing.Model.PassengerModel
{
    public class PassengerStateExceptions : Exception
    {
        public PassengerStateExceptions() : base()
        {
        }

        public PassengerStateExceptions(string? message) : base(message)
        {
        }

        public PassengerStateExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
