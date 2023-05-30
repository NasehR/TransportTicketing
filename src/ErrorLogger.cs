using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTicketing
{
    public class ErrorLogger
    {
        private readonly string _logFilePath;

        public ErrorLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogError(Exception ex, string message)
        {
            string logEntry = $"[ERROR] {DateTime.Now} : {ex.GetType()} -> {message}";

            WriteToLogFile(logEntry);
        }

        public void LogInfo(string message)
        {
            string logEntry = $"[INFO] {DateTime.Now} : {message}";

            WriteToLogFile(logEntry);
        }

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