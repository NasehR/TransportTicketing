using System;

namespace TransportTicketing.Model
{
    public interface ITransportObserver
    {
        void Notify();
    }
}
