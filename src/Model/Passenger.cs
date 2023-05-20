using System;
using Microsoft.VisualBasic;

namespace TransportTicketing.Model
{
    public class Passenger
    {
        private IPassengerState _currentStanding;
        public string Id { get; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; }
        public int BillerCode { get; }

        public Passenger(string id, string name, int billerCode, DateTime dob)
        {
            Id = id;
            Name = name;
            BillerCode = billerCode;
            DateOfBirth = dob;
            _currentStanding = new GoodStandingState(this);
        }

        public override string ToString()
        {
            return $"Passenger ID: \t\t{Id} \n" +
                $"Passenger Name: \t{Name} \n" +
                $"Date of Birth: \t\t{DateOfBirth.ToString("dd/MM/yyyy")} \n" +
                $"Biller Code: \t\t{BillerCode} \n" +
                $"Current Standing: \t{GetCurrentStanding()} \n";
        }

        public void SetState(IPassengerState passengerState)
        {
            _currentStanding = passengerState;
        }

        public string GetCurrentStanding()
        {
            return _currentStanding.Standing();
        }

        public void Good()
        {
            _currentStanding.Good();
        }

        public void Debt()
        {
            _currentStanding.Debt();
        }

        public void Cancel()
        {
            _currentStanding.Cancel();
        }
    }
}
