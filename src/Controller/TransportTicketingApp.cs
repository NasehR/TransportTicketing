﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.Model.PassengerModel;

namespace TransportTicketing.Controller
{
    public class TransportTicketingApp
    {
        public Dictionary<int, IMenu> Options { get; set; }
        public Dictionary<string, TransportClient> Transports;
        public Dictionary<string, PassengerController> Passengers;

        public TransportTicketingApp(Dictionary<string, TransportClient> transport, Dictionary<string, PassengerController> passengers) 
        {
            Transports = transport;
            Passengers = passengers;
            Options = new Dictionary<int, IMenu>();
            Options.Add(1, new TransportOperation());
            Options.Add(2, new PassengerOperation());
            Options.Add(3, new Quit());
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TransportTicketingApp(Dictionary<string, TransportClient> transport)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Transports = transport;
            Options = new Dictionary<int, IMenu>();
            Options.Add(1, new TransportOperation());
            Options.Add(2, new PassengerOperation());
            Options.Add(3, new Quit());
        }

        public void Statement(int user)
        {
            Options[user].Statement();
        }

        public void Run(int user) {
            Options[user].Run();
        }
    }
}