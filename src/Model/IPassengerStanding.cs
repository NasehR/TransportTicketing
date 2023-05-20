using System;

namespace TransportTicketing.Model
{
    public abstract class PassengerState
    {
        protected Passenger _passenger;
        public abstract string Standing();
        public abstract void Good();
        public abstract void Debt();
        public abstract void Cancel();
    }

    public class GoodStandingState : PassengerState
    {
        public GoodStandingState(Passenger passenger) 
        {
            _passenger = passenger;
        }

        public override string Standing()
        {
            return "Good Standing";
        }

        public override void Good()
        {
            Console.WriteLine("Passenger has good standing");
        }

        public override void Debt()
        {
            Console.WriteLine("Good -> Debt");
            this._passenger.SetState(new DebtState(_passenger));
        }

        public override void Cancel()
        {
            Console.WriteLine("Good -> Cancel");
            this._passenger.SetState(new CancelState(_passenger));
        }
    }

    public class DebtState : PassengerState
    {
        public DebtState(Passenger passenger)
        {
            _passenger = passenger;
        }

        public override string Standing()
        {
            return "In Debt";
        }

        public override void Good()
        {
            Console.WriteLine("Debt -> Good");
            this._passenger.SetState(new GoodStandingState(_passenger));
        }

        public override void Debt()
        {
            Console.WriteLine("Passenger is in debt");
        }

        public override void Cancel()
        {
            Console.WriteLine("Debt -> Cancel");
            this._passenger.SetState(new CancelState(_passenger));
        }
    }

    public class CancelState : PassengerState
    {
        public CancelState(Passenger passenger)
        {
            _passenger = passenger;
        }

        public override string Standing()
        {
            return "Cancelled";
        }

        public override void Good()
        {
            Console.WriteLine("Cancel -> Good");
        }

        public override void Debt()
        {
            Console.WriteLine("Cancel -> Debt");
        }

        public override void Cancel()
        {
            Console.WriteLine("Passenger is cancelled");
        }
    }
}
