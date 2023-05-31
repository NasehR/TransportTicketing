using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Model;
using TransportTicketing.Model.PassengerModel;
using TransportTicketing.Controller.TransportController;

namespace TransportTicketing.View
{
    /// <summary>
    /// Represents a ticket for transportation.
    /// </summary>
    public class Ticket
    {
        private ITicketStatus _ticketStatus;
        public int Id { get; set; }
        public TransportClient TransportMode { get; set; }
        public Passenger Passenger { get; set; }

        /// <summary>
        /// Initializes a new instance of the Ticket class.
        /// </summary>
        /// <param name="id">The ID of the ticket.</param>
        /// <param name="transport">The transport mode for the ticket.</param>
        /// <param name="passenger">The passenger associated with the ticket.</param>
        public Ticket(int id, TransportClient transport, Passenger passenger)
        {
            Id = id;
            TransportMode = transport;
            _ticketStatus = new OpenTicket(this);
            Passenger = passenger;
        }

        /// <summary>
        /// Returns a string representation of the ticket.
        /// </summary>
        /// <returns>A string containing the ticket ID and transport mode.</returns>
        public override string ToString()
        {
            return $"{Id}: {TransportMode}";
        }

        /// <summary>
        /// Sets the validity of the ticket.
        /// </summary>
        /// <param name="ticketStatus">The ticket status to set.</param>
        public void SetValidity(ITicketStatus ticketStatus)
        {
            _ticketStatus = ticketStatus;
        }

        /// <summary>
        /// Checks if the ticket is valid.
        /// </summary>
        /// <returns>True if the ticket is valid, false otherwise.</returns>
        public bool Validity()
        {
            bool isValid = false;
            if (_ticketStatus.ToString().Equals("Valid"))
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Marks the ticket as valid.
        /// </summary>
        public void Valid()
        {
            _ticketStatus.Valid();
        }

        /// <summary>
        /// Marks the ticket as not valid.
        /// </summary>
        public void NotValid()
        {
            _ticketStatus.NotValid();
        }
    }
}