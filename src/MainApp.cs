using System;
using TransportTicketing.Model;

namespace TransportTicketing
{
    public static class MainApp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("MainApp");
                string id = "SR070148614";
                string name = "Naseh Rizvi";
                int billerCode = 241513;
                DateTime dob = new DateTime(2002, 5, 6);
                Passenger passenger = new Passenger(id, name, billerCode, dob);
                
                passenger.Good();
                Console.WriteLine(passenger.GetCurrentStanding());

                Console.WriteLine("Change to Debt");

                passenger.Debt();
                Console.WriteLine(passenger.GetCurrentStanding());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}