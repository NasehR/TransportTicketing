using System;
using static System.Collections.Specialized.BitVector32;

namespace TransportTicketing.Model
{
    public abstract class Transport
    {
        // Data structure to store the number of stations on the route
        //protected Dictionary<String, Station> Stations { get; }
        protected LinkedList<Passenger> Passengers { get; }
        //protected Dictionary<String, Station> Stations { get; }
        public abstract int GetNumberOfStations();
        public abstract int GetNumberOfPassengers();

        //public abstract Station CurrentLocation();
        //Passenger Id: arguement
        //public abstract void AddPassengers();
        //Passenger Id: arguement
        //public abstract void RemovePassenger();
        public abstract void GetCurrentStatus();
    }

    public class Bus : Transport
    {
        public Bus()
        {
            //Stations = new Dictionary<String, Station>();
            //Passengers = new LinkedList<Passenger>();
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

        /*
        * Passenger Id: arguement
        public override void AddPassengers()
        {
            throw new NotImplementedException();
        }
        */

        /*
         * Passenger Id: arguement
        public override void RemovePassenger()
        {
            throw new NotImplementedException();
        }
        */

        public override void GetCurrentStatus()
        {
            throw new NotImplementedException();
        }
    }

    public class Train : Transport
    {
        public Train()
        {
            //Stations = new Dictionary<String, Station>();
            //Passengers = new LinkedList<Passenger>();
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

        /*
         * Passenger Id: arguement
        public override void AddPassengers()
        {
            throw new NotImplementedException();
        }
        */

        /*
         * Passenger Id: arguement
        public override void RemovePassenger()
        {
            throw new NotImplementedException();
        }
        */

        public override void GetCurrentStatus()
        {
            throw new NotImplementedException();
        }
    }
}
