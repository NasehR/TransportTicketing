using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TransportTicketing.View;

namespace TransportTicketing.Model
{
    public interface ITicketStatus
    {
        string ToString();

        void Valid();

        void NotValid();
    }

    public class OpenTicket : ITicketStatus
    {
        protected Ticket _ticket;

        public OpenTicket(Ticket ticket)
        {
            _ticket = ticket;
        }

        public override string ToString()
        {
            return "Valid";
        }

        public void Valid()
        {
            Console.WriteLine("Ticket is open");
        }

        public void NotValid()
        {
            if (_ticket.Validity().Equals(ToString()))
            {
                _ticket.SetValidity(new ClosedTicket(_ticket));
            }
        }
    }

    public class ClosedTicket : ITicketStatus
    {
        protected Ticket _ticket;

        public ClosedTicket(Ticket ticket)
        {
            _ticket = ticket;
        }

        public override string ToString()
        {
            return "Not Valid";
        }

        public void Valid()
        {
            if (_ticket.Validity().Equals(ToString()))
            {
                _ticket.SetValidity(new ClosedTicket(_ticket));
            }
        }

        public void NotValid()
        {
            Console.WriteLine("Ticket is closed");
        }
    }
}