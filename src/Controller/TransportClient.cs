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

        public void AddPassenger(PassengerController passenger)
        {
            _transport.AddPassengers(passenger);
        }

        public void RemovePassenger(PassengerController passenger)
        {
            _transport.RemovePassenger(passenger);
        }

        public void AddStation(Station station)
        {
            _transport.AddStation(station);
        }

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
                    Console.WriteLine("Invalid standing. Please enter 'ontime', 'delayed', or 'cancelled'.");
                    break;
            }
        }

        public List<PassengerController> GetCurrentPassengers()
        {
            return _transport.GetCurrentPassengers();
        }
    }
}
