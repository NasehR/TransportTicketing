using System;

namespace TransportTicketing.Model
{
    public abstract class Transport
    {
        //private ITransportStatus _transportStatus
        public LinkedList<Passenger> Passengers { get; set; }
        public Dictionary<string, Station> Stations { get; set; }
        public abstract int GetNumberOfStations();
        public abstract int GetNumberOfPassengers();

        public abstract void AddPassengers(Passenger passenger);
        public abstract void RemovePassenger(Passenger passenger);
        //public abstract Station CurrentLocation();
        //public abstract string GetCurrentStatus();
    }

    public class Bus : Transport
    {
        public Bus()
        {
            Stations = new Dictionary<string, Station>();
            Passengers = new LinkedList<Passenger>();
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

            return Passengers.Count();
        }

        public override void AddPassengers(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public override void RemovePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        /*
        public override void GetCurrentStatus()
        {
            throw new NotImplementedException();
        }
        */
    }

    public class Train : Transport
    {
        public Train()
        {
            Stations = new Dictionary<String, Station>();
            Passengers = new LinkedList<Passenger>();
        }

        public override int GetNumberOfStations()
        {
            if (Stations == null)
            {
                throw new NullReferenceException();
            }

            return Stations.Count();
        }

        public override int GetNumberOfPassengers()
        {
            if (Passengers == null)
            {
                throw new NullReferenceException();
            }

            return Passengers.Count();
        }
        
        public override void AddPassengers(Passenger passenger)
        {
            throw new NotImplementedException();
        }
        
        public override void RemovePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        /*
        public override void GetCurrentStatus()
        {
            throw new NotImplementedException();
        }
        */
  
    }
}
