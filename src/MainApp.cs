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
                IPassengerState passengerState = new GoodStandingState();
                Passenger passenger = new Passenger(id, name, billerCode, passengerState);
                passenger.Good();
            
            
                IPassengerState passengerState1 = new DebtState();
                passenger.setState(passengerState1);
                passenger.Debt();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}