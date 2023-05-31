using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing.Model
{
    public class TicketExceptions : Exception
    {
        public TicketExceptions() : base()
        {
        }

        public TicketExceptions(string? message) : base(message)
        {
        }

        public TicketExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
