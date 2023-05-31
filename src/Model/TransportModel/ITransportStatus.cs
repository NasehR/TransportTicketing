namespace TransportTicketing.Model.TransportModel
{
    /// <summary>
    /// Represents the interface for transport status.
    /// </summary>
    public interface ITransportStatus
    {
        /// <summary>
        /// Returns a string representation of the transport status.
        /// </summary>
        /// <returns>A string representing the transport status.</returns>
        string ToString();

        /// <summary>
        /// Notifies that the transport has arrived on time.
        /// </summary>
        void OnTime();

        /// <summary>
        /// Notifies that the transport is delayed.
        /// </summary>
        void Delayed();

        /// <summary>
        /// Notifies that the transport has been cancelled.
        /// </summary>
        void Cancelled();
    }

    /// <summary>
    /// Represents the state of a transport being on time.
    /// </summary>
    public class OnTimeState : ITransportStatus
    {
        protected Transport _transport;

        /// <summary>
        /// Initializes a new instance of the OnTimeState class with the specified transport.
        /// </summary>
        /// <param name="transport">The transport associated with this state.</param>
        public OnTimeState(Transport transport)
        {
            _transport = transport;
        }

        /// <summary>
        /// Returns a string representation of the state.
        /// </summary>
        /// <returns>A string indicating that the transport is on time.</returns>
        public override string ToString()
        {
            return "On Time";
        }

        /// <summary>
        /// Throws a TransportStateExceptions indicating that the transport is already on time.
        /// </summary>
        /// <exception cref="TransportStateExceptions">Thrown when the transport is already on time.</exception>
        public void OnTime()
        {
            throw new TransportStateExceptions("The transport is on time");
        }

        /// <summary>
        /// Changes the state of the transport to DelayedState if it is currently on time.
        /// </summary>
        public void Delayed()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new DelayedState(_transport));
            }
        }

        /// <summary>
        /// Changes the state of the transport to CancelledState if it is currently on time.
        /// </summary>
        public void Cancelled()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new CancelledState(_transport));
            }
        }
    }

    /// <summary>
    /// Represents a delayed state of a transport.
    /// </summary>
    public class DelayedState : ITransportStatus
    {
        protected Transport _transport;

        /// <summary>
        /// Initializes a new instance of the DelayedState class.
        /// </summary>
        /// <param name="transport">The transport associated with this state.</param>
        public DelayedState(Transport transport)
        {
            _transport = transport;
        }

        /// <summary>
        /// Returns a string representation of the DelayedState object.
        /// </summary>
        /// <returns>A string representation of the DelayedState object.</returns>
        public override string ToString()
        {
            return "Delayed";
        }

        /// <summary>
        /// Transition to the OnTimeState if the transport is currently in the DelayedState.
        /// </summary>
        public void OnTime()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new OnTimeState(_transport));
            }
        }

        /// <summary>
        /// Throws a TransportStateException if the transport is already in the DelayedState.
        /// </summary>
        /// <exception cref="TransportStateException">Thrown when the transport is already delayed.</exception>
        public void Delayed()
        {
            throw new TransportStateExceptions("The transport is already delayed.");
        }

        /// <summary>
        /// Transition to the CancelledState if the transport is currently in the DelayedState.
        /// </summary>
        public void Cancelled()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new CancelledState(_transport));
            }
        }
    }

    /// <summary>
    /// Represents the cancelled state of a transport.
    /// </summary>
    public class CancelledState : ITransportStatus
    {
        protected Transport _transport;

        /// <summary>
        /// Initializes a new instance of the CancelledState class with the specified transport.
        /// </summary>
        /// <param name="transport">The transport associated with this state.</param>
        public CancelledState(Transport transport)
        {
            _transport = transport;
        }

        /// <summary>
        /// Returns a string representation of the CancelledState.
        /// </summary>
        /// <returns>A string representation of the CancelledState.</returns>
        public override string ToString()
        {
            return "Cancelled";
        }

        /// <summary>
        /// Throws a TransportStateExceptions indicating that the transport is cancelled and cannot be on time.
        /// </summary>
        /// <exception cref="TransportStateExceptions">Thrown when the transport is cancelled and cannot be on time.</exception>
        public void OnTime()
        {
            throw new TransportStateExceptions("The transport is cancelled, therefore can not be on time");
        }

        /// <summary>
        /// Throws a TransportStateExceptions indicating that the transport is cancelled and cannot be delayed.
        /// </summary>
        /// <exception cref="TransportStateExceptions">Thrown when the transport is cancelled and cannot be delayed.</exception>
        public void Delayed()
        {
            throw new TransportStateExceptions("The transport is cancelled, therefore can not be delayed");
        }

        /// <summary>
        /// Throws a TransportStateExceptions indicating that the transport is already cancelled.
        /// </summary>
        /// <exception cref="TransportStateExceptions">Thrown when the transport is already cancelled.</exception>
        public void Cancelled()
        {
            throw new TransportStateExceptions("The transport is already cancelled");
        }
    }
}