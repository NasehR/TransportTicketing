using System;

namespace TransportTicketing.Model.PassengerModel
{
    /// <summary>
    /// Interface to toggle between different statuses of a passenger.
    /// </summary>
    public interface IPassengerStatus
    {
        string ToString();

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
        public override string ToString()
        {
            // On bus/train name
            //_passenger.GetLastTicket().ModeOfTransport();
            return "On Transport";
        }

        /// <summary>
        /// Transition to the "on transport" status.
        /// </summary>
        public void On()
        {
            throw new PassengerStateExceptions("The Passenger is already on a transport");
        }

        /// <summary>
        /// Transition to the "off transport" status.
        /// </summary>
        public void Off()
        {
            if (_passenger.GetCurrentStatus().Equals(ToString()))
            {
                _passenger.SetStatus(new OffTransport(_passenger));
            }
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
        public override string ToString()
        {
            return "Off Transport";
        }

        /// <summary>
        /// Transition to the "on transport" status.
        /// </summary>
        public void On()
        {
            if (_passenger.GetCurrentStatus().Equals(ToString()))
            {
                _passenger.SetStatus(new OnTransport(_passenger));
            }
        }

        /// <summary>
        /// Transition to the "off transport" status.
        /// </summary>
        public void Off()
        {
            throw new PassengerStateExceptions("Passenger is already off transport");
        }
    }
}