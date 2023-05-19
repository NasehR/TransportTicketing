using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Model;

namespace TransportTicketing.Model
{
    public interface IPassengerState
    {
        public void Good(); 
        public void Debt();
        public void Cancel();
    }

    public class GoodStandingState : IPassengerState
    {
        public void Good()
        {
            Console.WriteLine("Passenger has good standing");
        }

        public void Debt()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }
    }

    public class DebtState : IPassengerState
    {
        public void Good()
        {
            throw new NotImplementedException();
        }

        public void Debt()
        {
            Console.WriteLine("Passenger is in debt");
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }
    }

    public class CancelState : IPassengerState
    {
        public void Good()
        {
            throw new NotImplementedException();
        }

        public void Debt()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            Console.WriteLine("Passenger is cancelled");
        }
    }
}
