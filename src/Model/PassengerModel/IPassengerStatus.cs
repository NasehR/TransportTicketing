using System;

namespace TransportTicketing.Model.PassengerModel
{
    /// <summary>
    /// Represents an interface for passenger status.
    /// </summary>
    public interface IPassengerStatus
    {
        /// <summary>
        /// Returns a string representation of the passenger status.
        /// </summary>
        /// <returns>A string representation of the passenger status.</returns>
        string ToString();

        /// <summary>
        /// Turns on the passenger status.
        /// </summary>
        void On();

        /// <summary>
        /// Turns off the passenger status.
        /// </summary>
        void Off();
    }

    /// <summary>
    /// Represents the status of a passenger being on a transport.
    /// </summary>
    public class OnTransport : IPassengerStatus
    {
        protected Passenger _passenger;

        /// <summary>
        /// Initializes a new instance of the OnTransport class with the specified passenger.
        /// </summary>
        /// <param name="passenger">The passenger.</param>
        public OnTransport(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns a string representation of the OnTransport object.
        /// </summary>
        /// <returns>The string "On Transport".</returns>
        public override string ToString()
        {
            // On bus/train name
            //_passenger.GetLastTicket().ModeOfTransport();
            return "On Transport";
        }

        /// <summary>
        /// Throws an exception indicating that the passenger is already on a transport.
        /// </summary>
        /// <exception cref="PassengerStateExceptions">Thrown when the passenger is already on a transport.</exception>
        public void On()
        {
            throw new PassengerStateExceptions("The Passenger is already on a transport");
        }

        /// <summary>
        /// Changes the passenger's status to OffTransport if the current status is "On Transport".
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
    /// Represents the status of a passenger being off transport.
    /// </summary>
    public class OffTransport : IPassengerStatus
    {
        protected Passenger _passenger;

        /// <summary>
        /// Initializes a new instance of the OffTransport class with the specified passenger.
        /// </summary>
        /// <param name="passenger">The passenger associated with this status.</param>
        public OffTransport(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns a string representation of the OffTransport status.
        /// </summary>
        /// <returns>A string representing the OffTransport status.</returns>
        public override string ToString()
        {
            return "Off Transport";
        }

        /// <summary>
        /// Changes the passenger's status to OnTransport if the current status is OffTransport.
        /// </summary>
        public void On()
        {
            if (_passenger.GetCurrentStatus().Equals(ToString()))
            {
                _passenger.SetStatus(new OnTransport(_passenger));
            }
        }

        /// <summary>
        /// Throws a PassengerStateExceptions if called, as the passenger is already off transport.
        /// </summary>
        /// <exception cref="PassengerStateExceptions">Thrown when the passenger is already off transport.</exception>
        public void Off()
        {
            throw new PassengerStateExceptions("Passenger is already off transport");
        }
    }
}