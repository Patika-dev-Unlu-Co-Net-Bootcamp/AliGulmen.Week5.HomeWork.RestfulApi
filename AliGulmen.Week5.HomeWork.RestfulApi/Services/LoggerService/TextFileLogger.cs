using System;
using System.IO;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Services.LoggerService
{
    public class TextFileLogger : ILoggerService
    {
        public void Log(string message)
        {
            using (StreamWriter writer = File.AppendText("actions.log"))
            {
                writer.WriteLine("[TextFileLogger] - " + message);
            }

        }
    }
}
