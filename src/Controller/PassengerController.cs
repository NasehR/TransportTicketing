using System;
using System.Globalization;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    /// <summary>
    /// The class is responsible for passenger related operations
    /// </summary>
    public class PassengerController
    {
        private Passenger _passenger;

        /// <summary>
        /// Constructor to initalise the PassengerController with initial passenger details.
        /// </summary>
        /// <param name="id">Passenger id</param>
        /// <param name="name">Passenger name</param>
        /// <param name="billerCode">Passenger billercode</param>
        /// <param name="dob">Passenger's date of birth</param>
        public PassengerController(string id, string name, int billerCode, string dob)
        {
            DateTime Dob = DateTime.Parse(dob);
            _passenger = new Passenger(id, name, billerCode, Dob);
        }

        /// <summary>
        /// Update the passenger standing through the input
        /// </summary>
        /// <param name="standing"></param>
        public void UpdatePassengerStanding(string standing)
        {
            switch (standing.ToLower())
            {
                case "good":
                    _passenger.Good();
                    break;
                case "debt":
                    _passenger.Debt();
                    break;
                case "cancel":
                    _passenger.Cancel();
                    break;
                default:
                    Console.WriteLine("Invalid standing. Please enter 'good', 'debt', or 'cancel'.");
                    break;
            }
        }

        /// <summary>
        /// Method to printout the details of the passenger
        /// </summary>
        public void PrintPassengerDetails()
        {
            Console.WriteLine(_passenger.ToString());
        }

        /// <summary>
        /// Method to create a ticket.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Boarding()
        {
            throw new NotImplementedException(/*TransportMode transportMode, string entryTime*/);
            /*
            DateTime entry = DateTime.Parse(entryTime);
            _passenger.EnterTransport(transportMode, entry);
            */
        }

        /// <summary>
        /// Method to update the ticket with the exiting time
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Leaving()
        {
            throw new NotImplementedException();
            /*
            _passsenger.Ticket.SetLeaveTime() 
             */
        }
    }
}
