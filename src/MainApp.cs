using System;
using System.Collections.Generic;
using TransportTicketing.Model;
using TransportTicketing.Controller;

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
                const string id = "SR070148614";
                const string name = "Naseh Rizvi";
                const int billerCode = 241513;
                const string dob = "06/05/2002";
                PassengerController passenger = new PassengerController(id, name, billerCode, dob);
                Passengers.Add(id, passenger);

                Console.WriteLine("Passenger Added to Dictionary");

                Transport train = new Train();

                train.AddPassengers(passenger);
                Console.WriteLine("Passenger Added to Transport");
                Console.WriteLine(train.GetCurrentStatus());
                Console.WriteLine("Transport should be delayed");
                train.Delayed();
                Console.WriteLine(train.GetCurrentStatus());


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