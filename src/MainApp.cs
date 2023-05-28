using System;
using System.Collections.Generic;
using TransportTicketing.Model;
using TransportTicketing.Controller;
using TransportTicketing.View;

namespace TransportTicketing
{
    public static class MainApp
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("MainApp");
                Dictionary<String, PassengerController> Passengers = new Dictionary<String, PassengerController>();
                Dictionary<String, Ticket> Tickets = new Dictionary<String, Ticket>();
                Dictionary<String, Transport> Transports = new Dictionary<String, Transport>();

                const string id = "SR070148614";
                const string name = "Naseh Rizvi";
                const int billerCode = 241513;
                const string dob = "06/05/2002";
                PassengerController passenger = new PassengerController(id, name, billerCode, dob);
                Passengers.Add(id, passenger);

                Console.WriteLine("Passenger Added to Dictionary");

                string trainNumber = "999";
                Transport bus = new Train();
                Transports.Add(trainNumber, bus);

                Console.WriteLine(passenger.GetCurrentStatus());

                passenger.Boarding(1, bus);
                Console.WriteLine(passenger.GetCurrentStatus());

                passenger.Leaving();
                Console.WriteLine(passenger.GetCurrentStatus());

                //int num = train.GetNumberOfPassengers();

                //Console.WriteLine(num);

                //foreach (var p in train.GetCurrentPassengers())
                //{
                //    Console.WriteLine("Begin for each loop");
                //    p.PrintPassengerDetails();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}