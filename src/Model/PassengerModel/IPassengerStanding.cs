using System;

/// <summary>
/// State pattern to change the standing of the passenger
/// </summary>
namespace TransportTicketing.Model.PassengerModel
{
    /// <summary>
    /// Represents an interface for managing standing passengers.
    /// </summary>
    public interface IPassengerStanding
    {
        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>A string representation of the object.</returns>
        string ToString();

        /// <summary>
        /// Performs an action to indicate the passenger is in good standing.
        /// </summary>
        void Good();

        /// <summary>
        /// Performs an action to indicate the passenger has a debt.
        /// </summary>
        void Debt();

        /// <summary>
        /// Performs an action to cancel the passenger's standing status.
        /// </summary>
        void Cancel();
    }

    /// <summary>
    /// Represents the state of a passenger in good standing.
    /// </summary>
    public class GoodStandingState : IPassengerStanding
    {
        protected Passenger _passenger;

        /// <summary>
        /// Initializes a new instance of the GoodStandingState class.
        /// </summary>
        /// <param name="passenger">The passenger associated with this state.</param>
        public GoodStandingState(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns a string representation of the standing (Good Standing).
        /// </summary>
        /// <returns>A string representing the standing.</returns>
        public override string ToString()
        {
            return "Good Standing";
        }

        /// <summary>
        /// Throws an exception indicating that the passenger already has good standing.
        /// </summary>
        /// <exception cref="PassengerStateExceptions"></exception>
        public void Good()
        {
            throw new PassengerStateExceptions("Passenger has good standing");
        }

        /// <summary>
        /// Transitions the passenger to the debt state if the current standing is good standing.
        /// </summary>
        public void Debt()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                _passenger.SetStanding(new DebtState(_passenger));
            }
        }

        /// <summary>
        /// Transitions the passenger to the cancel state if the current standing is good standing.
        /// </summary>
        public void Cancel()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                _passenger.SetStanding(new CancelState(_passenger));
            }
        }
    }

    /// <summary>
    /// Represents a state where a passenger is in debt.
    /// Implements the IPassengerStanding interface.
    /// </summary>
    public class DebtState : IPassengerStanding
    {
        protected Passenger _passenger;

        /// <summary>
        /// Initializes a new instance of the DebtState class with the specified passenger.
        /// </summary>
        /// <param name="passenger">The passenger associated with this state.</param>
        public DebtState(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns a string representation of the DebtState object.
        /// </summary>
        /// <returns>A string indicating that the passenger is in debt.</returns>
        public override string ToString()
        {
            return "In Debt";
        }

        /// <summary>
        /// Changes the passenger's standing to GoodStandingState if the current standing is "In Debt".
        /// </summary>
        public void Good()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                _passenger.SetStanding(new GoodStandingState(_passenger));
            }
        }

        /// <summary>
        /// Throws a PassengerStateException with the message "Passenger is in debt".
        /// </summary>
        /// <exception cref="PassengerStateExceptions"></exception>
        public void Debt()
        {
            throw new PassengerStateExceptions("Passenger is in debt");
        }

        /// <summary>
        /// Changes the passenger's standing to CancelState if the current standing is "In Debt".
        /// </summary>
        public void Cancel()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                _passenger.SetStanding(new CancelState(_passenger));
            }
        }
    }

    /// <summary>
    /// Represents the state of a passenger who has been cancelled.
    /// Implements the IPassengerStanding interface.
    /// </summary>
    public class CancelState : IPassengerStanding
    {
        protected Passenger _passenger;

        /// <summary>
        /// Initializes a new instance of the CancelState class with the specified passenger.
        /// </summary>
        /// <param name="passenger">The passenger associated with this state.</param>
        public CancelState(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Returns a string representation of the CancelState object.
        /// </summary>
        /// <returns>A string representation of the CancelState object.</returns>
        public override string ToString()
        {
            return "Cancelled";
        }

        /// <summary>
        /// Throws a PassengerStateExceptions indicating that a passenger cannot transition from cancelled to good standing.
        /// </summary>
        /// <exception cref="PassengerStateExceptions"></exception>
        public void Good()
        {
            throw new PassengerStateExceptions("Passenger can not go from cancelled to good standing");
        }

        /// <summary>
        /// Throws a PassengerStateExceptions indicating that a passenger cannot transition from cancelled to debt.
        /// </summary>
        /// <exception cref="PassengerStateExceptions"></exception>
        public void Debt()
        {
            throw new PassengerStateExceptions("Passenger can not go from cancelled to debt");
        }

        /// <summary>
        /// Throws a PassengerStateExceptions indicating that the passenger is already cancelled.
        /// </summary>
        /// <exception cref="PassengerStateExceptions"></exception>
        public void Cancel()
        {
            throw new PassengerStateExceptions("Passenger is cancelled");
        }
    }
}