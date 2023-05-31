using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TransportTicketing.View;

namespace TransportTicketing.Model
{
    /// <summary>
    /// Interface representing the status of a ticket.
    /// </summary>
    public interface ITicketStatus
    {
        /// <summary>
        /// Returns a string representation of the ticket status.
        /// </summary>
        string ToString();

        /// <summary>
        /// Marks the ticket as valid.
        /// </summary>
        void Valid();

        /// <summary>
        /// Marks the ticket as not valid.
        /// </summary>
        void NotValid();
    }

    /// <summary>
    /// Represents the OpenTicket class, which implements the ITicketStatus interface.
    /// </summary>
    public class OpenTicket : ITicketStatus
    {
        protected Ticket _ticket;

        /// <summary>
        /// Initializes a new instance of the OpenTicket class with the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket associated with this OpenTicket instance.</param>
        public OpenTicket(Ticket ticket)
        {
            _ticket = ticket;
        }

        /// <summary>
        /// Returns a string representation of the OpenTicket object.
        /// </summary>
        /// <returns>A string representation of the OpenTicket object.</returns>
        public override string ToString()
        {
            return "Valid";
        }

        /// <summary>
        /// Throws a TicketExceptions indicating that the ticket is already open.
        /// </summary>
        /// <exception cref="TicketExceptions">Thrown if the ticket is already valid</exception>
        public void Valid()
        {
            throw new TicketExceptions("Ticket is open");
        }

        /// <summary>
        /// Changes the ticket's status to ClosedTicket if it is valid.
        /// </summary>
        public void NotValid()
        {
            if (_ticket.Validity())
            {
                _ticket.SetValidity(new ClosedTicket(_ticket));
            }
        }
    }

    /// <summary>
    /// Represents a closed ticket.
    /// </summary>
    public class ClosedTicket : ITicketStatus
    {
        protected Ticket _ticket;

        /// <summary>
        /// Initializes a new instance of the ClosedTicket class with the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket associated with this closed status.</param>
        public ClosedTicket(Ticket ticket)
        {
            _ticket = ticket;
        }

        /// <summary>
        /// Returns a string representation of the closed ticket.
        /// </summary>
        /// <returns>A string representation of the closed ticket.</returns>
        public override string ToString()
        {
            return "Not Valid";
        }

        /// <summary>
        /// Throws a TicketExceptions when attempting to validate a closed ticket.
        /// </summary>
        /// <exception cref="TicketExceptions">Thrown when ticket attempts to transition to open</exception>
        public void Valid()
        {
            throw new TicketExceptions("Ticket can not be open once closed");
        }

        /// <summary>
        /// Throws a TicketExceptions when attempting to invalidate a closed ticket.
        /// </summary>
        /// <exception cref="TicketExceptions">Thrown if the ticket is already not valid</exception>
        public void NotValid()
        {
            throw new TicketExceptions("Ticket is closed");
        }
    }
}