using System;
using System.Runtime.CompilerServices;

namespace TransportTicketing.Model
{
    public interface ITransportStatus
    {
        string ToString();
        void OnTime();
        void Delayed();
        void Cancelled();
    }

    public class OnTimeState : ITransportStatus
    {
        protected Transport _transport;

        public OnTimeState(Transport transport)
        {
            _transport = transport;
        }

        public override string ToString()
        {
            return $"{_transport.ToString} is on time";
        }

        public void OnTime()
        {
            Console.WriteLine("The transport is on time");
        }

        public void Delayed()
        {
            _transport.SetStatus(new DelayedState(_transport));
        }

        public void Cancelled()
        {
            _transport.SetStatus(new CancelledState(_transport));
        }
    }

    public class DelayedState : ITransportStatus
    {
        protected Transport _transport;

        public DelayedState(Transport transport)
        {
            _transport = transport;
        }
        
        public override string ToString()
        {
            return $"{_transport.ToString} is delayed";
        }

        public void OnTime()
        {
            _transport.SetStatus(new OnTimeState(_transport));
        }

        public void Delayed()
        {
            Console.WriteLine("The transport is already delayed.");
        }

        public void Cancelled()
        {
            _transport.SetStatus(new CancelledState(_transport));
        }
    }

    public class CancelledState : ITransportStatus
    {
        protected Transport _transport;

        public CancelledState(Transport transport)
        {
            _transport = transport;
        }

        public override string ToString()
        {
            return $"{_transport.ToString} is cancelled";
        }

        public void OnTime()
        {
            _transport.SetStatus(new OnTimeState(_transport));
        }
        
        public void Delayed()
        {
            _transport.SetStatus(new DelayedState(_transport));
        }

        public void Cancelled()
        {
            Console.WriteLine("The transport is already cancelled");
        }
    }
}
