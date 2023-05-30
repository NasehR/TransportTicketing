using System;
using TransportTicketing.Model.TransportModel;

namespace TransportTicketing.Controller.TransportController
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
                _ => throw new TransportExceptions($"{_transportationMode} is an invalid form of transport"),
            };
        }
    }
}