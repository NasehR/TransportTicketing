﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller;
using TransportTicketing.Model;

namespace TransportTicketing.View
{
    public class Ticket
    {
        private ITicketStatus _ticketStatus;
        public int Id { get; set; }
        public Transport TransportMode { get; set; }
        public Passenger Passenger { get; set; }

        public Ticket(int id, Transport transport, Passenger passenger)
        {
            Id = id;
            TransportMode = transport;
            _ticketStatus = new OpenTicket(this);
            Passenger = passenger;
        }

        public override string ToString()
        {
            return $"{Id}: {TransportMode}";
        }

        public void SetValidity(ITicketStatus ticketStatus)
        {
            _ticketStatus = ticketStatus;
        }

        public string Validity()
        {
            return _ticketStatus.ToString();
        }

        public void Valid()
        {
            _ticketStatus.Valid();
        }

        public void NotValid()
        {
            _ticketStatus.NotValid();
        }
    }
}