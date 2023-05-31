using System;

namespace TransportTicketing.View
{
    /// <summary>
    /// Represents a station with a name.
    /// </summary>
    public class Station
    {
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the Station class with the specified name.
        /// </summary>
        /// <param name="name">The name of the station.</param>
        public Station(string name)
        {
            Name = name;
        }
    }
}