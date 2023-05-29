using System;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;

namespace TransportTicketing.Model.PassengerModel
{
    public class Passenger
    {
        private IPassengerStanding _currentStanding;
        private IPassengerStatus _currentStatus;
        public string Id { get; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; }
        public int BillerCode { get; }
        public LinkedList<Ticket> MyTickets { get; }

        public Passenger(string id, string name, int billerCode, DateTime dob)
        {
            Id = id;
            Name = name;
            BillerCode = billerCode;
            DateOfBirth = dob;
            _currentStanding = new GoodStandingState(this);
            _currentStatus = new OffTransport(this);
            MyTickets = new LinkedList<Ticket>();
        }

        public override string ToString()
        {
            return $"Passenger ID: \t\t{Id} \n" +
                $"Passenger Name: \t{Name} \n" +
                $"Date of Birth: \t\t{DateOfBirth:dd/MM/yyyy} \n" +
                $"Biller Code: \t\t{BillerCode} \n" +
                $"Current Standing: \t{GetCurrentStanding()} \n" +
                $"Current Status: \t{GetCurrentStatus()}";
        }

        public void SetState(IPassengerStanding passengerState)
        {
            _currentStanding = passengerState;
        }

        public void SetStatus(IPassengerStatus passengerStatus)
        {
            _currentStatus = passengerStatus;
        }

        public string GetCurrentStanding()
        {
            return _currentStanding.ToString();
        }

        public string GetCurrentStatus()
        {
            return _currentStatus.ToString();
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

        public void On()
        {
            _currentStatus.On();
        }

        public void Off()
        {
            _currentStatus.Off();
        }

        public void Notify()
        {
            ExitTransport();
            Off();
        }

        /// <summary>
        /// Method to simulate when a passenger enters transportation mode.
        /// </summary>
        /// <param name="transportMode"></param>
        /// <param name="entryTime"></param>
        public void EnterTransport(int ticketNumber, TransportClient transportMode)
        {
            Ticket ticket = new Ticket(ticketNumber, transportMode, this);
            MyTickets.AddLast(ticket);
            On();
        }

        /// <summary>
        /// Method to simulate when a passenger exits a bus/train
        /// </summary>
        /// <param name="exitTime"></param>
        public void ExitTransport()
        {
            Ticket ticket = MyTickets.Last();
            ticket.NotValid();
            Off();
        }

        /// <summary>
        /// Method to get the last ticket
        /// </summary>
        /// <returns>The last ticket</returns>
        /// <exception cref="Exception"></exception>
        public Ticket GetLastTicket()
        {
            if (MyTickets.Count == 0)
            {
                // custom exception
                throw new Exception("No tickets were bought.");
            }

            return MyTickets.Last();
        }
    }
}
