using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.common.logger
{
    // CustomLogging/LoggerManager.cs
    using System;
    using System.IO;

    public class LoggerManager : ILoggerManager
    {
        private readonly string _logFilePath = "Logs/custom-log.txt";  // Customize the path as needed

        public LoggerManager()
        {
            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }
        }

        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogWarn(string message)
        {
            WriteLog("WARN", message);
        }

        public void LogDebug(string message)
        {
            WriteLog("DEBUG", message);
        }

        public void LogError(string message)
        {
            WriteLog("ERROR", message);
        }

        private void WriteLog(string level, string message)
        {
            var logMessage = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }

}
