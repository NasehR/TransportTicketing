using System;

namespace TransportTicketing.Model.TransportModel
{
    /// <summary>
    /// Represents an interface for observing transportation events.
    /// </summary>
    public interface ITransportObserver
    {
        /// <summary>
        /// Notifies the observer about a passenger event.
        /// </summary>
        void NotifyPassenger();
    }
}