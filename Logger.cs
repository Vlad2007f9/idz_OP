using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idz_OP
{
    public sealed class Logger
    {
        private static Logger instan;
        private readonly string LoggerPath = "logger.txt";
        private Logger()
        {
            if (File.Exists(LoggerPath))
            {
                File.WriteAllText(LoggerPath, string.Empty);
            }
            else
            {
                File.Create(LoggerPath).Dispose();
            }
        }
        public static Logger Instance
        {
            get
            {
                if (instan == null)
                    instan = new Logger();

                return instan;
            }
        }
        public void LogEvent(string EventType, int line, int column, char symbol)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string entry = $"{time}; {line}; {column}; {EventType}; '{symbol}'";

            File.AppendAllText(LoggerPath, entry + Environment.NewLine);
        }
        public string GetLogger()
        {
            return File.ReadAllText(LoggerPath);
        }
    }
}
