using System;
using System.Globalization;
using TransportTicketing.Model;

namespace TransportTicketing.Controller
{
    public class PassengerController
    {
        private Passenger _passenger;

        public PassengerController(string id, string name, int billerCode, string dob)
        {
            DateTime Dob = DateTime.Parse(dob);
            _passenger = new Passenger(id, name, billerCode, Dob);
        }

        public void UpdatePassengerName(string newName)
        {
            _passenger.Name = newName;
            Console.WriteLine("Passenger name updated successfully.");
        }

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

        public void PrintPassengerDetails()
        {
            Console.WriteLine(_passenger.ToString());
        }
    }
}
