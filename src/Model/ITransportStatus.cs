using System;

namespace TransportTicketing.Model
{
    public interface ITransportStatus
    {
        string ToString();
        void Delayed();
        void OnTime();
        void Cancelled();
    }

    public class OnTimeState : ITransportStatus
    {
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
