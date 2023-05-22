using System;

namespace TransportTicketing.Model
{
    /// <summary>
    /// Interface to toggle between different statuses of a passenger.
    /// </summary>
    public interface IPassengerStatus
    {
        string Status();
        void On();
        void Off();
    }

    /// <summary>
    /// Represents the status of a passenger on transport.
    /// </summary>
    public class OnTransport : IPassengerStatus
    {
        protected Passenger _passenger;

        /// <summary>
        /// Constructor to initialize the OnTransport status.
        /// </summary>
        /// <param name="passenger">The passenger associated with this status.</param>
        public OnTransport(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns the current status of the passenger.
        /// </summary>
        /// <returns>On Transport</returns>
        public string Status()
        {
            return "On Transport";
        }

        /// <summary>
        /// Transition to the "on transport" status.
        /// </summary>
        public void On()
        {
            Console.WriteLine("Passenger is already on transport");
        }

        /// <summary>
        /// Transition to the "off transport" status.
        /// </summary>
        public void Off() 
        { 
            Console.WriteLine("Getting off");
            _passenger.SetStatus(new OffTransport(_passenger));
        }
    }

    /// <summary>
    /// Represents the status of a passenger off transport.
    /// </summary>
    public class OffTransport : IPassengerStatus
    {
        protected Passenger _passenger;

        /// <summary>
        /// Constructor to initialize the OffTransport status.
        /// </summary>
        /// <param name="passenger">The passenger associated with this status.</param>
        public OffTransport(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns the current status of the passenger.
        /// </summary>
        /// <returns>Off Transport</returns>
        public string Status()
        {
            return "Off Transport";
        }

        /// <summary>
        /// Transition to the "on transport" status.
        /// </summary>
        public void On()
        {
            _passenger.SetStatus(new OnTransport(_passenger));
        }

        /// <summary>
        /// Transition to the "off transport" status.
        /// </summary>
        public void Off()
        {
            Console.WriteLine("Passenger is already off transport");
        }
    }
}
