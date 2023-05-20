using System;
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
                string id = "SR070148614";
                string name = "Naseh Rizvi";
                int billerCode = 241513;
                string dob = "06/05/2002";
                PassengerController passenger = new PassengerController(id, name, billerCode, dob);

                passenger.PrintPassengerDetails();

                passenger.UpdatePassengerStanding("CaNcEl");

                passenger.PrintPassengerDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}