using System;
using TransportTicketing.Model.TransportModel;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.View;

namespace TransportTicketing.Controller.TransportController
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

        public void AddPassenger(int ticketNumber, PassengerController passenger)
        {
            _transport.AddPassengers(ticketNumber, passenger);
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
                    throw new TransportExceptions($"{status} as a status does not exits");
            }
        }

        public List<PassengerController> GetCurrentPassengers()
        {
            return _transport.GetCurrentPassengers();
        }
    }
}
