using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing.Controller.TransportController
{
    public class TransportExceptions : Exception
    {
        public TransportExceptions() : base()
        {
        }

        public TransportExceptions(string? message) : base(message)
        {
        }

        public TransportExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}