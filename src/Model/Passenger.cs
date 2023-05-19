using System;

namespace TransportTicketing.Model
{
    public class Passenger
    {
        public string Id { get; }
        public string Name { get; set; }
        public int BillerCode { get; }

        private IPassengerState _currentStanding;

        public Passenger(string Id, string Name, int BillerCode, IPassengerState passengerState)
        {
            this.Id = Id;
            this.Name = Name;
            this.BillerCode = BillerCode;
            _currentStanding = passengerState;
        }

        public void setState(IPassengerState passengerState)
        {
            _currentStanding = passengerState;
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
