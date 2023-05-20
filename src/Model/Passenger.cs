using System;

namespace TransportTicketing.Model
{
    public class Passenger
    {
        private PassengerState _currentStanding;
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

        public void SetState(PassengerState passengerState)
        {
            _currentStanding = passengerState;
        }

        public string GetCurrentStanding()
        {
            return $"Passenger {Id}: \t\t{_currentStanding.Standing()}";
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
