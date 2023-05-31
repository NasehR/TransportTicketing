using System;
using System.Collections.Generic;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;

namespace TransportTicketing.Model.TransportModel
{
    public abstract class Transport
    {
        public ITransportStatus? TransportStatus { get; set; }
        public List<PassengerController>? Passengers { get; set; }
        public Dictionary<string, Station>? Stations { get; set; }

        // - "SetStatus" which is responsible for setting the status of the transport.
        public abstract void SetStatus(ITransportStatus transportStatus);

        // - "GetNumberOfStations" which returns the total number of stations.
        public abstract int GetNumberOfStations();

        // - "GetNumberOfPassengers" which returns the total number of passengers.
        public abstract int GetNumberOfPassengers();

        // - "AddPassengers" which adds a passenger to the transport's passenger list.
        public abstract void AddPassengers(int ticketNumber, PassengerController passenger);

        // - "RemovePassenger" which removes a passenger from the transport's passenger list.
        public abstract void RemovePassenger(PassengerController passenger);

        // - "AddStation" which adds a station to the transport's station dictionary.
        public abstract void AddStation(Station station);

        // - "GetCurrentStatus" which returns the current status of the transport.
        public abstract string GetCurrentStatus();

        // - "OnTime" which simulates the transport arriving on time.
        public abstract void OnTime();

        // - "Delayed" which simulates the transport being delayed.
        public abstract void Delayed();

        // - "Cancelled" which simulates the transport being cancelled.
        public abstract void Cancelled();

        // - "GetCurrentPassengers" which returns the list of passengers currently on the transport.
        public abstract List<PassengerController> GetCurrentPassengers();
    }

    /// <summary>
    /// Represents a Bus that inherits from the Transport class.
    /// </summary>
    public class Bus : Transport
    {
        /// <summary>
        /// Initializes a new instance of the Bus class.
        /// </summary>
        public Bus()
        {
            Stations = new Dictionary<string, Station>();
            Passengers = new List<PassengerController>();
            TransportStatus = new OnTimeState(this);
        }

        /// <summary>
        /// Returns a string representation of the Bus.
        /// </summary>
        /// <returns>A string representing the Bus.</returns>
        public override string ToString()
        {
            return "Bus";
        }

        /// <summary>
        /// Sets the status of the Bus using the provided transportStatus.
        /// </summary>
        /// <param name="transportStatus">The ITransportStatus to set.</param>
        public override void SetStatus(ITransportStatus transportStatus)
        {
            TransportStatus = transportStatus;
        }

        /// <summary>
        /// Returns the number of stations available in the Bus.
        /// </summary>
        /// <returns>The number of stations in the Bus.</returns>
        /// <exception cref="TransportExceptions">Thrown is no stations are on its route</exception>
        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                throw new TransportExceptions("There are no stations in this transports route.");
            }

            return Stations.Count;
        }

        /// <summary>
        /// Returns the number of passengers currently in the Bus.
        /// </summary>
        /// <returns>The number of passengers in the Bus.</returns>
        /// <exception cref="TransportExceptions">Thrown when no passengers are on the transport</exception>
        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                throw new TransportExceptions("There are no passengers on this transports.");
            }

            return Passengers.Count;
        }

        /// <summary>
        /// Adds a passenger with the specified ticket number to the Bus.
        /// </summary>
        /// <param name="ticketNumber">The ticket number of the passenger.</param>
        /// <param name="passenger">The PassengerController to add.</param>
        public override void AddPassengers(int ticketNumber, PassengerController passenger)
        {
            Passengers?.Add(passenger);
            passenger.UpdatePassengerStatus("on");
        }

        /// <summary>
        /// Removes the specified passenger from the Bus.
        /// </summary>
        /// <param name="passenger">The PassengerController to remove.</param>
        public override void RemovePassenger(PassengerController passenger)
        {
            Passengers?.Remove(passenger);
            passenger.UpdatePassengerStatus("off");
        }

        /// <summary>
        /// Adds a station to the Bus.
        /// </summary>
        /// <param name="station">The Station to add.</param>
        public override void AddStation(Station station)
        {
            Stations?.Add(station.Name, station);
        }

        /// <summary>
        /// Returns the current status of the Bus as a string.
        /// </summary>
        /// <returns>The current status of the Bus.</returns>
        public override string GetCurrentStatus()
        {
            string? s = null;
            Console.WriteLine(TransportStatus != null);
            if (TransportStatus != null)
            {
                s = TransportStatus.ToString();
            }

            return s ?? string.Empty;
        }

        /// <summary>
        /// Sets the status of the Bus to On Time.
        /// </summary>
        public override void OnTime()
        {
            TransportStatus?.OnTime();
        }

        /// <summary>
        /// Sets the status of the Bus to Delayed.
        /// </summary>
        public override void Delayed()
        {
            TransportStatus?.Delayed();
        }

        /// <summary>
        /// Sets the status of the Bus to Cancelled.
        /// </summary>
        public override void Cancelled()
        {
            TransportStatus?.Cancelled();
        }

        /// <summary>
        /// Returns a list of all the current passengers in the Bus.
        /// </summary>
        /// <returns>A list of PassengerController representing the current passengers in the Bus.</returns>
        /// <exception cref="TransportExceptions">Thrown when no passengers are on the transport</exception>
        public override List<PassengerController> GetCurrentPassengers()
        {
            if (Passengers == null)
            {
                throw new TransportExceptions("There are no passengers on this transport");
            }

            return Passengers;
        }
    }

    public class Train : Transport
    {
        /// <summary>
        /// Initializes a new instance of the Train class.
        /// </summary>
        public Train()
        {
            Stations = new Dictionary<string, Station>();
            Passengers = new List<PassengerController>();
            TransportStatus = new OnTimeState(this);
        }

        /// <summary>
        /// Returns a string representation of the Bus.
        /// </summary>
        /// <returns>A string representing the Bus.</returns>
        public override string ToString()
        {
            return "Train";
        }

        /// <summary>
        /// Sets the status of the Bus using the provided transportStatus.
        /// </summary>
        /// <param name="transportStatus">The ITransportStatus to set.</param>
        public override void SetStatus(ITransportStatus transportStatus)
        {
            TransportStatus = transportStatus;
        }

        /// <summary>
        /// Returns the number of stations available in the Bus.
        /// </summary>
        /// <returns>The number of stations in the Bus.</returns>
        /// <exception cref="TransportExceptions">Thrown is no stations are on its route</exception>
        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                // custom exception
                throw new TransportExceptions("There are no stations on this transpports route.");
            }

            return Stations.Count;
        }

        /// <summary>
        /// Returns the number of passengers currently in the Bus.
        /// </summary>
        /// <returns>The number of passengers in the Bus.</returns>
        /// <exception cref="TransportExceptions">Thrown when no passengers are on the transport</exception>
        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                // custom exception
                throw new TransportExceptions("There are no passengers on this transport.");
            }

            return Passengers.Count;
        }

        /// <summary>
        /// Adds a passenger with the specified ticket number to the Bus.
        /// </summary>
        /// <param name="ticketNumber">The ticket number of the passenger.</param>
        /// <param name="passenger">The PassengerController to add.</param>
        public override void AddPassengers(int ticketNumber, PassengerController passenger)
        {
            Passengers?.Add(passenger);
            passenger.UpdatePassengerStatus("on");
        }

        /// <summary>
        /// Removes the specified passenger from the Bus.
        /// </summary>
        /// <param name="passenger">The PassengerController to remove.</param>
        public override void RemovePassenger(PassengerController passenger)
        {
            Passengers?.Remove(passenger);
            passenger.UpdatePassengerStatus("off");
        }

        /// <summary>
        /// Adds a station to the Bus.
        /// </summary>
        /// <param name="station">The Station to add.</param>
        public override void AddStation(Station station)
        {
            Stations?.Add(station.Name, station);
        }

        /// <summary>
        /// Returns the current status of the Bus as a string.
        /// </summary>
        /// <returns>The current status of the Bus.</returns>
        public override string GetCurrentStatus()
        {
            string? s = null;
            if (TransportStatus != null)
            {
                s = TransportStatus.ToString();
            }

            return s ?? string.Empty;
        }

        /// <summary>
        /// Sets the status of the Bus to On Time.
        /// </summary>
        public override void OnTime()
        {
            TransportStatus?.OnTime();
        }
        
        /// <summary>
        /// Sets the status of the Bus to Delayed.
        /// </summary>
        public override void Delayed()
        {
            TransportStatus?.Delayed();
        }

        /// <summary>
        /// Sets the status of the Bus to Cancelled.
        /// </summary>
        public override void Cancelled()
        {
            TransportStatus?.Cancelled();
        }

        /// <summary>
        /// Returns a list of all the current passengers in the Bus.
        /// </summary>
        /// <returns>A list of PassengerController representing the current passengers in the Bus.</returns>
        /// <exception cref="TransportExceptions">Thrown when no passengers are on the transport</exception>
        public override List<PassengerController> GetCurrentPassengers()
        {
            if (Passengers == null)
            {
                // custom exception
                throw new TransportExceptions("There are no passengers on this transport.");
            }

            return Passengers;
        }
    }
}