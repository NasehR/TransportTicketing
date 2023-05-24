using System;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class TransportClient
    {
        private Transport _transport;

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
        
        public void AddPassenger(Passenger passenger)
        {
            _transport.AddPassengers(passenger);
        }

        public void RemovePassenger(Passenger passenger)
        {
            _transport.RemovePassenger(passenger);
        }
    
        public void AddStation(Station station)
        {
            _transport.AddStation(station);
        }
    }
}
