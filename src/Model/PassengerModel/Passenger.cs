using System;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.View;

namespace TransportTicketing.Model.PassengerModel
{
    /// <summary>
    /// Represents a passenger with various properties and behaviors.
    /// </summary>
    public class Passenger
    {
        private IPassengerStanding _currentStanding;
        private IPassengerStatus _currentStatus;
        public string Id { get; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; }
        public int BillerCode { get; }
        public LinkedList<Ticket> MyTickets { get; }

        /// <summary>
        /// Initializes a new instance of the Passenger class.
        /// </summary>
        /// <param name="id">Unique identifier of the passenger.</param>
        /// <param name="name">Name of the passenger.</param>
        /// <param name="billerCode">Biller code of the passenger.</param>
        /// <param name="dob">Date of birth of the passenger.</param>
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

        /// <summary>
        /// Returns a string representation of the Passenger object.
        /// </summary>
        /// <returns>A string representing the Passenger object.</returns>
        public override string ToString()
        {
            return $"Passenger ID: \t\t{Id} \n" +
                $"Passenger Name: \t{Name} \n" +
                $"Date of Birth: \t\t{DateOfBirth:dd/MM/yyyy} \n" +
                $"Biller Code: \t\t{BillerCode} \n" +
                $"Current Standing: \t{GetCurrentStanding()} \n" +
                $"Current Status: \t{GetCurrentStatus()}";
        }

        /// <summary>
        /// Sets the current standing state of the passenger.
        /// </summary>
        /// <param name="passengerStanding">The new passenger standing state.</param>
        public void SetStanding(IPassengerStanding passengerStanding)
        {
            _currentStanding = passengerStanding;
        }

        /// <summary>
        /// Sets the current status of the passenger.
        /// </summary>
        /// <param name="passengerStatus">The new passenger status.</param>
        public void SetStatus(IPassengerStatus passengerStatus)
        {
            _currentStatus = passengerStatus;
        }

        /// <summary>
        /// Returns the current standing state of the passenger as a string.
        /// </summary>
        /// <returns>The current standing state of the passenger.</returns>
        public string GetCurrentStanding()
        {
            return _currentStanding.ToString();
        }

        /// <summary>
        /// Returns the current status of the passenger as a string.
        /// </summary>
        /// <returns>The current status of the passenger.</returns>
        public string GetCurrentStatus()
        {
            return _currentStatus.ToString();
        }

        /// <summary>
        /// Performs the "Good" action on the current standing state.
        /// </summary>
        public void Good()
        {
            _currentStanding.Good();
        }

        /// <summary>
        /// Performs the "Debt" action on the current standing state.
        /// </summary>
        public void Debt()
        {
            _currentStanding.Debt();
        }

        /// <summary>
        /// Performs the "Cancel" action on the current standing state.
        /// </summary>
        public void Cancel()
        {
            _currentStanding.Cancel();
        }

        /// <summary>
        /// Performs the "On" action on the current status.
        /// </summary>
        public void On()
        {
            _currentStatus.On();
        }

        /// <summary>
        /// Performs the "Off" action on the current status.
        /// </summary>
        public void Off()
        {
            _currentStatus.Off();
        }

        /// <summary>
        /// Notifies the passenger by exiting the transport and turning off the status.
        /// </summary>
        public void Notify()
        {
            ExitTransport();
            Off();
        }

        /// <summary>
        /// Allows the passenger to enter the transport by creating a new ticket and turning on the status.
        /// </summary>
        /// <param name="ticketNumber">The ticket number.</param>
        /// <param name="transportMode">The transport mode.</param>
        public void EnterTransport(int ticketNumber, TransportClient transportMode)
        {
            Ticket ticket = new(ticketNumber, transportMode, this);
            MyTickets.AddLast(ticket);
            On();
        }

        /// <summary>
        /// Allows the passenger to exit the transport by invalidating the last ticket and turning off the status.
        /// </summary>
        public void ExitTransport()
        {
            Ticket ticket = MyTickets.Last();
            ticket.NotValid();
            Off();
        }

        /// <summary>
        /// Returns the last ticket owned by the passenger.
        /// </summary>
        /// <returns>The last ticket owned by the passenger.</returns>
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