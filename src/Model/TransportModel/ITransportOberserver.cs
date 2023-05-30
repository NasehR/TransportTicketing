using System;

namespace TransportTicketing.Model.TransportModel
{
    public interface ITransportObserver
    {
        void NotifyPassenger();
    }
}