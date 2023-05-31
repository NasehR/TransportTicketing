using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing
{
    /// <summary>
    /// Represents a class for logging errors and information to a log file.
    /// </summary>
    public class ErrorLogger
    {
        private readonly string _logFilePath;

        /// <summary>
        /// Initializes a new instance of the ErrorLogger class with the specified log file path.
        /// </summary>
        /// <param name="logFilePath">The path to the log file.</param>
        public ErrorLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        /// <summary>
        /// Logs an error along with the provided exception and message to the log file.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        /// <param name="message">The error message.</param>
        public void LogError(Exception ex, string message)
        {
            string logEntry = $"[ERROR] {DateTime.Now} : {ex.GetType()} -> {message}";

            WriteToLogFile(logEntry);
        }

        /// <summary>
        /// Logs an informational message to the log file.
        /// </summary>
        /// <param name="message">The information message.</param>
        public void LogInfo(string message)
        {
            string logEntry = $"[INFO] {DateTime.Now} : {message}";

            WriteToLogFile(logEntry);
        }

        /// <summary>
        /// Writes the log entry to the log file.
        /// </summary>
        /// <param name="logEntry">The log entry to write.</param>
        private void WriteToLogFile(string logEntry)
        {
            try
            {
                using StreamWriter writer = new(_logFilePath, true);
                writer.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}