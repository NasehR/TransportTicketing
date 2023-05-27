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
            switch (_transportationMode.ToLower())
            {
                case "bus":
                    return new Bus();
                case "train":
                    return new Train();
                default:
                    throw new ArgumentException("Invalid transportation mode.");
            }
        }
    }
}
