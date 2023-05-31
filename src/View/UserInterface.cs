using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTicketing.Controller;
using TransportTicketing.Controller.PassengersController;
using TransportTicketing.Controller.TransportController;
using TransportTicketing.Model.PassengerModel;
using TransportTicketing.Model.TransportModel;

namespace TransportTicketing.View
{
    /// <summary>
    /// Represents the user interface for the transport ticketing application.
    /// </summary>
    public class UserInterface
    {
        public TransportTicketingApp App { get; set; }
        private readonly ErrorLogger _logger;

        /// <summary>
        /// Initializes a new instance of the UserInterface class.
        /// </summary>
        /// <param name="app">The transport ticketing application.</param>
        /// <param name="logger">The error logger.</param>
        public UserInterface(TransportTicketingApp app, ErrorLogger logger)
        {
            App = app;
            _logger = logger;
        }

        /// <summary>
        /// Displays the main menu and handles user input.
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("Main Method");
            int user = 0;
            string userString;
            do
            {
                try
                {
                    Console.WriteLine("1)\tTransport Operations");
                    Console.WriteLine("2)\tPassenger Operations");
                    Console.WriteLine("0)\tExit");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    userString = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    user = Convert.ToInt32(userString);

                    App.Statement(user);
                    App.Run(user);
                }
                catch (PassengerExceptions ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
                catch (TransportExceptions ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
                catch (PassengerStateExceptions ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
                catch (TransportStateExceptions ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"{ex.Message}");
                }
            } while (user != 0);
        }
    }
}
