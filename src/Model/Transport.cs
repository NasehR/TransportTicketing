using System;

namespace TransportTicketing.Model
{
    public abstract class Transport
    {
        protected int NumberOfStations { get; }

        public abstract void Move();
    }

    public class Bus : Transport
    {
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }

    public class Train : Transport
    {
        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
