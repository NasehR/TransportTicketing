using System;
using System.Collections.Generic;
using TransportTicketing.Model;
using TransportTicketing.Controller;

namespace TransportTicketing
{
    public static class MainApp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("MainApp");
                Dictionary<String, Passenger> Passengers = new Dictionary<String, Passenger>();
                string id = "SR070148614";
                string name = "Naseh Rizvi";
                int billerCode = 241513;
                string dob = "06/05/2002";
                DateTime Dob = DateTime.Parse(dob);
                Passenger passenger = new Passenger(id, name, billerCode, Dob);
                Passengers.Add(id, passenger);
                Console.WriteLine(Passengers[id].ToString());

                /*
                passenger.EnterTransport();
                Console.WriteLine(passenger.ToString());

                PassengerController passenger = new PassengerController(id, name, billerCode, dob);

                passenger.PrintPassengerDetails();

                passenger.UpdatePassengerStanding("CaNcEl");

                passenger.PrintPassengerDetails();
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}