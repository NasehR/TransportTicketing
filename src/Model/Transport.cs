using System;
using System.Collections.Generic;
using TransportTicketing.Controller;

namespace TransportTicketing.Model
{
    public abstract class Transport
    {
        public ITransportStatus? TransportStatus;
        public List<PassengerController>? Passengers { get; set; }
        public Dictionary<string, Station>? Stations { get; set; }

        public abstract void SetStatus(ITransportStatus transportStatus);
        public abstract int GetNumberOfStations();
        public abstract int GetNumberOfPassengers();
        public abstract void AddPassengers(PassengerController passenger);
        public abstract void RemovePassenger(PassengerController passenger);
        public abstract void AddStation(Station station);
        public abstract string GetCurrentStatus();
        public abstract void OnTime();
        public abstract void Delayed();
        public abstract void Cancelled();
        public abstract List<PassengerController> GetCurrentPassengers();
    }

    public class Bus : Transport
    {
        public Bus()
        {
            Stations = new Dictionary<string, Station>();
            Passengers = new List<PassengerController>();
            TransportStatus = new OnTimeState(this);
        }

        public override string ToString()
        {
            return "Bus";
        }

        public override void SetStatus(ITransportStatus transportStatus)
        {
            TransportStatus = transportStatus;
        }

        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                // custom exception
                throw new NullReferenceException();
            }

            return Stations.Count;
        }

        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                // custom exception
                throw new NullReferenceException();
            }

            return Passengers.Count;
        }

        public override void AddPassengers(PassengerController passenger)
        {
            Passengers?.Add(passenger);
        }

        public override void RemovePassenger(PassengerController passenger)
        {
            Passengers?.Remove(passenger);
        }

        public override void AddStation(Station station)
        {
            Stations?.Add(station.Name, station);
        }

        public override string GetCurrentStatus()
        {
            return TransportStatus.ToString();
        }

        public override void OnTime()
        {
            TransportStatus?.OnTime();
        }

        public override void Delayed()
        {
            TransportStatus?.Delayed();
        }

        public override void Cancelled()
        {
            TransportStatus?.Cancelled();
        }

        public override List<PassengerController> GetCurrentPassengers()
        {
            if (Passengers == null)
            {
                // custom exception
                throw new NullReferenceException();
            }

            return Passengers;
        }
    }

    public class Train : Transport
    {
        public Train()
        {
            Stations = new Dictionary<String, Station>();
            Passengers = new List<PassengerController>();
            TransportStatus = new OnTimeState(this);
        }

        public override string ToString()
        {
            return "Train";
        }

        public override void SetStatus(ITransportStatus transportStatus)
        {
            TransportStatus = transportStatus;
        }

        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                // custom exception
                throw new NullReferenceException();
            }

            return Stations.Count;
        }

        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                // custom exception
                throw new NullReferenceException();
            }

            return Passengers.Count;
        }

        public override void AddPassengers(PassengerController passenger)
        {
            Passengers?.Add(passenger);
        }

        public override void RemovePassenger(PassengerController passenger)
        {
            Passengers?.Remove(passenger);
        }

        public override void AddStation(Station station)
        {
            Stations?.Add(station.Name, station);
        }

        public override string GetCurrentStatus()
        {
            return TransportStatus.ToString();
        }

        public override void OnTime()
        {
            TransportStatus?.OnTime();
        }

        public override void Delayed()
        {
            TransportStatus?.Delayed();
        }

        public override void Cancelled()
        {
            TransportStatus?.Cancelled();
        }

        public override List<PassengerController> GetCurrentPassengers()
        {
            if (Passengers == null)
            {
                // custom exception
                throw new NullReferenceException();
            }

            return Passengers;
        }
    }
}
