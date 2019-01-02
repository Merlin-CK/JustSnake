using System;
using System.IO;

namespace JustSnake
{
    static class Logger
    {
        public static void Log(string message)
        {
            var time = DateTime.Now;

            string output = string.Format(
                "[{0} - {1}]\n{2}\n\n",
                time.ToShortDateString(),
                time.ToShortTimeString(),
                message
            );

            try
            {
                File.AppendAllText("log.txt", output);
            }
            catch
            {
                Console.Error.Write(message);
            }
        }
    }
}
