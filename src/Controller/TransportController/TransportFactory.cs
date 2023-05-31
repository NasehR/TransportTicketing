using System;
using TransportTicketing.Model.TransportModel;

namespace TransportTicketing.Controller.TransportController
{
    /// <summary>
    /// This class represents a factory for creating instances of different types of transportation.
    /// </summary>
    public class TransportFactory
    {
        private readonly string _transportationMode;

        /// <summary>
        /// Initializes a new instance of the TransportFactory class with the specified transportation mode.
        /// </summary>
        /// <param name="transportationMode">The mode of transportation.</param>
        public TransportFactory(string transportationMode)
        {
            _transportationMode = transportationMode;
        }

        /// <summary>
        /// Creates an instance of the specified transportation based on the transportation mode.
        /// </summary>
        /// <returns>An instance of the specified transportation.</returns>
        /// <exception cref="TransportExceptions">Thrown when an invalid form of transport is specified.</exception>
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