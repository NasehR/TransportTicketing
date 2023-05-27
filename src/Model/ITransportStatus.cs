using System;

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
            throw new NotImplementedException();
        }

        public void Delayed()
        {
            throw new NotImplementedException();
        }

        public void OnTime()
        {
            throw new NotImplementedException();
        }

        public void Cancelled()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Delayed()
        {
            throw new NotImplementedException();
        }

        public void OnTime()
        {
            throw new NotImplementedException();
        }
        
        public void Cancelled()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Delayed()
        {
            throw new NotImplementedException();
        }

        public void OnTime()
        {
            throw new NotImplementedException();
        }
        
        public void Cancelled()
        {
            throw new NotImplementedException();
        }
    }
}
