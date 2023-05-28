using System;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class TransportFactory
    {
        private readonly string _transportationMode;
        public TransportFactory(string transportationMode)
        {
            _transportationMode = transportationMode;
        }

        public Transport CreateTransportation()
        {
            return _transportationMode.ToLower() switch
            {
                "bus" => new Bus(),
                "train" => new Train(),
                _ => throw new ArgumentException("Invalid transportation mode."),
            };
        }
    }
}
