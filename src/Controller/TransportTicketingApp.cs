using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.Model.PassengerModel;
using TransportTicketing.View;

namespace TransportTicketing.Controller
{
    /// <summary>
    /// Represents a transport ticketing application.
    /// </summary>
    public class TransportTicketingApp
    {
        public Dictionary<int, IMenu> Options { get; set; }
        public Dictionary<string, TransportClient> Transports { get; set; }
        public Dictionary<string, PassengerController> Passengers { get; set; }
        public Dictionary<string, Ticket> Tickets { get; set; }

        /// <summary>
        /// Initializes a new instance of the TransportTicketingApp class with the specified transport clients and passengers.
        /// </summary>
        /// <param name="transport">The dictionary of transport clients.</param>
        /// <param name="passengers">The dictionary of passengers.</param>
        public TransportTicketingApp(Dictionary<string, TransportClient> transport, Dictionary<string, PassengerController> passengers)
        {
            Transports = transport;
            Passengers = passengers;
            Tickets = new Dictionary<string, Ticket>();
            Options = new Dictionary<int, IMenu>
            {
                { 1, new TransportOperation() },
                { 2, new PassengerOperation() },
                { 0, new Quit() }
            };
        }

        /// <summary>
        /// Initializes a new instance of the TransportTicketingApp class with the specified transport clients.
        /// </summary>
        /// <param name="transport">The dictionary of transport clients.</param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TransportTicketingApp(Dictionary<string, TransportClient> transport)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Transports = transport;
            Passengers = new Dictionary<string, PassengerController>();
            Options = new Dictionary<int, IMenu>
            {
                { 1, new TransportOperation() },
                { 2, new PassengerOperation() },
                { 0, new Quit() }
            };
        }

        /// <summary>
        /// Displays the statement for the specified user.
        /// </summary>
        /// <param name="user">The user for whom to display the statement.</param>
        public void Statement(int user)
        {
            Options[user].Statement();
        }

        /// <summary>
        /// Runs the specified user's chosen option.
        /// </summary>
        /// <param name="user">The user whose option should be executed.</param>
        public void Run(int user)
        {
            Options[user].Run(Transports, Passengers, Tickets);
        }
    }
}
