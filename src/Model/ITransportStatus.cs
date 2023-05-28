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
            return "On Time";
        }

        public void OnTime()
        {
            Console.WriteLine("The transport is on time");
        }

        public void Delayed()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new DelayedState(_transport));
            }
        }

        public void Cancelled()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new CancelledState(_transport));
            }
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
            return "Delayed";
        }

        public void OnTime()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new OnTimeState(_transport));
            }
        }

        public void Delayed()
        {
            Console.WriteLine("The transport is already delayed.");
        }

        public void Cancelled()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new CancelledState(_transport));
            }
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
            return "Cancelled";
        }

        public void OnTime()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new OnTimeState(_transport));
            }
        }

        public void Delayed()
        {
            if (_transport.GetCurrentStatus().Equals(ToString()))
            {
                _transport.SetStatus(new DelayedState(_transport));
            }
        }

        public void Cancelled()
        {
            Console.WriteLine("The transport is already cancelled");
        }
    }
}