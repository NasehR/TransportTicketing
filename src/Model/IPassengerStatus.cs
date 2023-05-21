using System;

namespace TransportTicketing.Model
{
    public interface IPassengerStatus
    {
        string Status();
        void On();
        void Off();
    }

    public class OnTransport : IPassengerStatus
    {
        protected Passenger _passenger;

        public OnTransport(Passenger passenger)
        {
            _passenger = passenger;
        }

        public string Status()
        {
            return "On Transport";
        }

        public void On()
        {
            Console.WriteLine("Passenger is already on transport");
        }

        public void Off() 
        { 
            Console.WriteLine("Getting off");
            _passenger.SetStatus(new OffTransport(_passenger));
        }
    }

    public class OffTransport : IPassengerStatus
    {
        protected Passenger _passenger;

        public string Status()
        {
            return "Off Transport";
        }

        public OffTransport(Passenger passenger)
        {
            _passenger = passenger;
        }

        public void On()
        {
            _passenger.SetStatus(new OnTransport(_passenger));
        }

        public void Off()
        {
            Console.WriteLine("Passenger is already off transport");
        }
    }
}
