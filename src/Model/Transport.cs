using System;
using System.Collections.Generic;

namespace TransportTicketing.Model
{
    public abstract class Transport
    {
        public ITransportStatus? TransportStatus;
        public List<Passenger>? Passengers { get; set; }
        public Dictionary<string, Station>? Stations { get; set; }

        public abstract int GetNumberOfStations();
        public abstract int GetNumberOfPassengers();

        public abstract void AddPassengers(Passenger passenger);
        public abstract void RemovePassenger(Passenger passenger);
        public abstract void AddStation(Station station);
        public abstract string GetCurrentStatus();
        public abstract List<Passenger> GetCurrentPassengers();
        //public abstract Station CurrentLocation();
    }

    public class Bus : Transport
    {
        public Bus()
        {
            Stations = new Dictionary<string, Station>();
            Passengers = new List<Passenger>();
            TransportStatus = new OnTimeState(this);
        }

        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                throw new NullReferenceException();
            }

            return Stations.Count;
        }

        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                throw new NullReferenceException();
            }

            return Passengers.Count;
        }

        public override void AddPassengers(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public override void RemovePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public override void AddStation(Station station)
        {
            Stations?.Add(station.Name, station);
        }

        public override string GetCurrentStatus()
        {
            throw new NotImplementedException();
        }

        public override List<Passenger> GetCurrentPassengers()
        {
            throw new NotImplementedException();
        }
    }

    public class Train : Transport
    {
        public Train()
        {
            Stations = new Dictionary<String, Station>();
            Passengers = new List<Passenger>();
            TransportStatus = new OnTimeState(this);
        }

        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                throw new NullReferenceException();
            }

            return Stations.Count;
        }

        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                throw new NullReferenceException();
            }

            return Passengers.Count;
        }
        
        public override void AddPassengers(Passenger passenger)
        {
            throw new NotImplementedException();
        }
        
        public override void RemovePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public override void AddStation(Station station)
        {
            Stations?.Add(station.Name, station);
        }

        public override string GetCurrentStatus()
        {
            throw new NotImplementedException();
        }

        public override List<Passenger> GetCurrentPassengers()
        {
            throw new NotImplementedException();
        }
    }
}
