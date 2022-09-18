using System;
using System.IO;

namespace FootballLeague.Common.Logging
{
    public static class Logger
    {
        private const string COMPLETE_FILE_NAME = "Logs.txt";
        private const bool APPEND_TO = true;

        public static void Log(string message)
        {
            try
            {
                using var sw = new StreamWriter(COMPLETE_FILE_NAME, APPEND_TO);
                sw.WriteLine(message);
            }
            catch (Exception)
            {
            }
        }
    }
}
