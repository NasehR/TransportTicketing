using System;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class TransportClient
    {
        private readonly Transport _transport;

        public TransportClient(TransportFactory transport, string transportationMode)
        {
            _transport = transport.CreateTransportation(transportationMode);
        }

        public int GetNumberOfStations()
        {
            return _transport.GetNumberOfStations();
        }

        public int GetNumberOfPassengers()
        {
            return _transport.GetNumberOfPassengers();
        }
        /*
         * Passenger Id: arguement
        public void AddPassenger()
        {
            _transport.AddPassengers();
        }
        */

        /*
         * Passenger Id: arguement
        public void RemovePassenger()
        {
            _transport.RemovePassenger();
        }
        */
    }
}
