using System;

namespace AliGulmen.Week5.HomeWork.RestfulApi.Services.LoggerService
{
    public class ConsoleLogger : ILoggerService
    {
     
        public void Log(string message)
        {
            Console.WriteLine("[ConsoleLogger] - " + message);
        }
    }
}
