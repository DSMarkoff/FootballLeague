using System;
using System.IO;

namespace FootballLeague.Services.Logging
{
    public static class Logger
    {
        public static void Log(string message)
        {
            try
            {
                using var sw = new StreamWriter("Logs.txt", true);
                sw.WriteLine(message);
            }
            catch (Exception)
            {
            }
        }
    }
}
