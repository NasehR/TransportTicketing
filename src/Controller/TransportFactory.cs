using System;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class TransportFactory
    {
        public Transport CreateTransportation(string transportationMode)
        {
            switch (transportationMode.ToLower())
            {
                case "bus":
                    return new Bus();
                case "Train":
                    return new Train();
                default:
                    throw new ArgumentException("Invalid transportation mode.");
            }
        }
    }
}
