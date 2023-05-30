﻿using System;
using System.Globalization;
using TransportTicketing.Model.TransportModel;
using TransportTicketing.Model.PassengerModel;
using TransportTicketing.Controller.TransportController;

namespace TransportTicketing.Controller.PassengersController
{
    /// <summary>
    /// The class is responsible for passenger related operations
    /// </summary>
    public class PassengerController : ITransportObserver
    {
        private readonly Passenger _passenger;
        public string Id { get; set; }
        public string Name { get; set; }
        public int BillerCode { get; set; }
        public string DOB { get; set; }

        /// <summary>
        /// Constructor to initalise the PassengerController with initial passenger details.
        /// </summary>
        /// <param name="id">Passenger's id</param>
        /// <param name="name">Passenger's name</param>
        /// <param name="billerCode">Passenger's billerCode</param>
        /// <param name="dob">Passenger's date of birth</param>
        public PassengerController(string id, string name, int billerCode, string dob)
        {
            Id = id;
            Name = name;
            BillerCode = billerCode;
            DOB = dob;
            DateTime Dob = DateTime.Parse(DOB);
            _passenger = new Passenger(id, name, billerCode, Dob);
        }

        /// <summary>
        /// Update the passenger standing through the input
        /// </summary>
        /// <param name="standing"></param>
        public void UpdatePassengerStanding(string standing)
        {
            switch (standing.ToLower())
            {
                case "good":
                    _passenger.Good();
                    break;
                case "debt":
                    _passenger.Debt();
                    break;
                case "cancel":
                    _passenger.Cancel();
                    break;
                default:
                    throw new PassengerExceptions($"{standing} as a standing does not exits");
            }
        }

        public void UpdatePassengerStatus(string status)
        {
            switch (status.ToLower())
            {
                case "on":
                    _passenger.On();
                    break;
                case "off":
                    _passenger.Off();
                    break;
                default:
                    throw new PassengerExceptions($"{status} as a status does not exits");
            }
        }

        /// <summary>
        /// Method to printout the details of the passenger
        /// </summary>
        public void PrintPassengerDetails()
        {
            Console.WriteLine(_passenger.ToString());
        }

        /// <summary>
        /// Method to create a ticket.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Boarding(int ticketNumber, TransportClient transportMode)
        {
            _passenger.EnterTransport(ticketNumber, transportMode);
            transportMode.AddPassenger(ticketNumber, this);
        }

        /// <summary>
        /// Method to update the ticket with the exiting time
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Leaving(TransportClient transportMode)
        {
            _passenger.ExitTransport();
            transportMode.RemovePassenger(this);
        }

        public string GetCurrentStatus()
        {
            return _passenger.GetCurrentStatus();
        }

        public string GetCurrentStanding()
        {
            return _passenger.GetCurrentStanding();
        }

        public void NotifyPassenger()
        {
            _passenger.Notify();
        }
    }
}
