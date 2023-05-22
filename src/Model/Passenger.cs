using System;
using Microsoft.VisualBasic;

namespace TransportTicketing.Model
{
    public class Passenger
    {
        private IPassengerState _currentStanding;
        private IPassengerStatus _currentStatus;
        public string Id { get; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; }
        public int BillerCode { get; }

        //public LinkedList<Ticket> Tickets { get; }

        public Passenger(string id, string name, int billerCode, DateTime dob)
        {
            Id = id;
            Name = name;
            BillerCode = billerCode;
            DateOfBirth = dob;
            _currentStanding = new GoodStandingState(this);
            _currentStatus = new OffTransport(this);
            //Tickets = new LinkedList<Ticket>();
        }

        public override string ToString()
        {
            return $"Passenger ID: \t\t{Id} \n" +
                $"Passenger Name: \t{Name} \n" +
                $"Date of Birth: \t\t{DateOfBirth.ToString("dd/MM/yyyy")} \n" +
                $"Biller Code: \t\t{BillerCode} \n" +
                $"Current Standing: \t{GetCurrentStanding()} \n" + 
                $"Current Status: \t{GetCurrentStatus()}";
        }

        public void SetState(IPassengerState passengerState)
        {
            _currentStanding = passengerState;
        }

        public void SetStatus(IPassengerStatus passengerStatus)
        {
            _currentStatus = passengerStatus;
        }

        public string GetCurrentStanding()
        {
            return _currentStanding.Standing();
        }

        public string GetCurrentStatus()
        {
            return _currentStatus.Status();
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
        /*
        public void EnterTransport(TransportMode transportMode, DateTime entryTime)
        {
            // Ticket ticket = new Ticket(transportMode, entryTime);
            // Tickets.AddLast(ticket);
            // _currentStatus.On();
        }
        */
        
        /*
        public void ExitTransport(DateTime exitTime)
        {
            // Ticket ticket = Tickets.Last();
            // _currentStatus.Off();
        }
        */
    }
}
