using System;
using System.IO;

namespace FootballLeague.Services.Logging
{
    public static class Logger
    {
        private const string COMPLETE_FILE_NAME = "Logs.txt";

        public static void Log(string message)
        {
            try
            {
                using var sw = new StreamWriter(COMPLETE_FILE_NAME, true);
                sw.WriteLine(message);
            }
            catch (Exception)
            {
            }
        }
    }
}
