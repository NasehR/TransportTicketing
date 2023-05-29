using System;

/// <summary>
/// State pattern to change the standing of the passenger
/// </summary>
namespace TransportTicketing.Model.PassengerModel
{
    /// <summary>
    /// Interface to toggle between difference states
    /// </summary>
    public interface IPassengerState
    {
        string ToString();
        void Good();
        void Debt();
        void Cancel();
    }

    /// <summary>
    /// Represents the state of a passenger in good standing.
    /// </summary>
    public class GoodStandingState : IPassengerState
    {
        protected Passenger _passenger;

        /// <summary>
        /// Constructor to initalise the GoodStandingState.
        /// </summary>
        /// <param name="passenger"></param>
        public GoodStandingState(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Printing the standing
        /// </summary>
        /// <returns>Good Standing</returns>
        public override string ToString()
        {
            return "Good Standing";
        }

        /// <summary>
        /// Transition to good standing state
        /// </summary>
        public void Good()
        {
            Console.WriteLine("Passenger has good standing");
        }

        /// <summary>
        /// Transition to debt state
        /// </summary>
        public void Debt()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                Console.WriteLine("Good -> Debt");
                _passenger.SetState(new DebtState(_passenger));
            }
        }

        /// <summary>
        /// Transition to cancel state
        /// </summary>
        public void Cancel()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                Console.WriteLine("Good -> Cancel");
                _passenger.SetState(new CancelState(_passenger));
            }
        }
    }

    /// <summary>
    /// Represents the state of a passenger in debt.
    /// </summary>
    public class DebtState : IPassengerState
    {
        protected Passenger _passenger;

        /// <summary>
        /// Constructor to initalise the DebtState.
        /// </summary>
        /// <param name="passenger"></param>
        public DebtState(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Printing the standing
        /// </summary>
        /// <returns>In Debt</returns>
        public override string ToString()
        {
            return "In Debt";
        }

        /// <summary>
        /// Transition to good standing state
        /// </summary>
        public void Good()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                Console.WriteLine("Debt -> Good");
                _passenger.SetState(new GoodStandingState(_passenger));
            }
        }

        /// <summary>
        /// Transition to debt state
        /// </summary>
        public void Debt()
        {
            Console.WriteLine("Passenger is in debt");
        }

        /// <summary>
        /// Transition to cancel state
        /// </summary>
        public void Cancel()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                Console.WriteLine("Debt -> Cancel");
                _passenger.SetState(new CancelState(_passenger));
            }
        }
    }

    /// <summary>
    /// Represents the state of a cancelled passenger.
    /// </summary>
    public class CancelState : IPassengerState
    {
        protected Passenger _passenger;

        /// <summary>
        /// Constructor to initalise the GoodStandingState.
        /// </summary>
        /// <param name="passenger"></param>
        public CancelState(Passenger passenger)
        {
            _passenger = passenger;
        }

        /// <summary>
        /// Printing the standing
        /// </summary>
        /// <returns>Cancelled</returns>
        public override string ToString()
        {
            return "Cancelled";
        }

        /// <summary>
        /// Transition to good standing state
        /// </summary>
        public void Good()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                Console.WriteLine("Cancel -> Good");
                _passenger.SetState(new GoodStandingState(_passenger));
            }
        }

        /// <summary>
        /// Transition to debt state
        /// </summary>
        public void Debt()
        {
            if (_passenger.GetCurrentStanding().Equals(ToString()))
            {
                Console.WriteLine("Cancel -> Debt");
                _passenger.SetState(new DebtState(_passenger));
            }
        }

        /// <summary>
        /// Transition to cancel state
        /// </summary>
        public void Cancel()
        {
            Console.WriteLine("Passenger is cancelled");
        }
    }
}
