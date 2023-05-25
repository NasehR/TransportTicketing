using System;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class TransportClient
    {
        private readonly Transport _transport;

        public TransportClient(TransportFactory transport)
        {

            _transport = transport.CreateTransportation();
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

        public List<Passenger> GetCurrrentPassengers()
        {
            throw new NotImplementedException();
        }
    }
}
