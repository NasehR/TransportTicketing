using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing.Model.TransportModel
{
    public class TransportStateExceptions : Exception
    {
        public TransportStateExceptions() : base()
        {
        }

        public TransportStateExceptions(string? message) : base(message)
        {
        }

        public TransportStateExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
