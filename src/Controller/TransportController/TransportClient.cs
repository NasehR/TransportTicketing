using System;
using TransportTicketing.Model.TransportModel;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.View;

namespace TransportTicketing.Controller.TransportController
{
    /// <summary>
    /// Represents a client for interacting with a transport system.
    /// </summary>
    public class TransportClient
    {
        private readonly Transport _transport;

        /// <summary>
        /// Initializes a new instance of the TransportClient class with a TransportFactory object.
        /// </summary>
        /// <param name="transport">The TransportFactory object used to create a Transport object.</param>
        public TransportClient(TransportFactory transport)
        {
            _transport = transport.CreateTransportation();
        }

        /// <summary>
        /// Gets the number of stations in the transport system.
        /// </summary>
        /// <returns>The number of stations.</returns>
        public int GetNumberOfStations()
        {
            return _transport.GetNumberOfStations();
        }

        /// <summary>
        /// Gets the number of passengers in the transport system.
        /// </summary>
        /// <returns>The number of passengers.</returns>
        public int GetNumberOfPassengers()
        {
            return _transport.GetNumberOfPassengers();
        }

        /// <summary>
        /// Adds a passenger to the transport system using the specified ticket number and PassengerController object.
        /// </summary>
        /// <param name="ticketNumber">The ticket number of the passenger.</param>
        /// <param name="passenger">The PassengerController object representing the passenger.</param>
        public void AddPassenger(int ticketNumber, PassengerController passenger)
        {
            _transport.AddPassengers(ticketNumber, passenger);
        }

        /// <summary>
        /// Removes a passenger from the transport system using the specified PassengerController object.
        /// </summary>
        /// <param name="passenger">The PassengerController object representing the passenger to be removed.</param>
        public void RemovePassenger(PassengerController passenger)
        {
            _transport.RemovePassenger(passenger);
        }

        /// <summary>
        /// Adds a station to the transport system.
        /// </summary>
        /// <param name="station">The Station object representing the station to be added.</param>
        public void AddStation(Station station)
        {
            _transport.AddStation(station);
        }

        /// <summary>
        /// Updates the transport status based on the specified status string.
        /// </summary>
        /// <param name="status">The status string representing the new status.</param>
        /// <exception cref="TransportExceptions">Thrown when an invalid status string is provided.</exception>
        public void UpdateTransportStatus(string status)
        {
            switch (status.ToLower())
            {
                case "ontime":
                    _transport.OnTime();
                    break;

                case "delayed":
                    _transport.Delayed();
                    break;

                case "cancelled":
                    _transport.Cancelled();
                    break;

                default:
                    throw new TransportExceptions($"{status} as a status does not exits");
            }
        }

        /// <summary>
        /// Gets the list of current passengers in the transport system.
        /// </summary>
        /// <returns>A list of PassengerController objects representing the current passengers.</returns>
        public List<PassengerController> GetCurrentPassengers()
        {
            return _transport.GetCurrentPassengers();
        }
    }
}