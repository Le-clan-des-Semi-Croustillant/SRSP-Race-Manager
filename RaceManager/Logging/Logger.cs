
namespace RaceManager
{
    public class Logger
    {
        private static Mutex mut = new Mutex();

        public static LoggingLevel LogLevel = LoggingLevel.OFF;
            /// <summary>
            /// Logs a message to the console if the level is greater than or equal to the current log level.
            /// </summary>
            /// 
        public static void log(LoggingLevel level, string caller, string message)
        {
            mut.WaitOne();

            if (level <= LogLevel && level != LoggingLevel.OFF)
            {
                Console.Write(String.Format("{0,-16} | ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                WriteLevel(level);
                WriteCaller(caller);
                Console.Write(": ");
                Console.WriteLine(String.Format("{1}", caller, message));

            }
            mut.ReleaseMutex();
        }

        private static void WriteCaller(string caller)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(String.Format("[{0,-20}] ", caller));
            Console.ResetColor();
        }

        private static void WriteLevel(LoggingLevel level)
        {
            switch (level)
            {
                case LoggingLevel.DEBUG:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LoggingLevel.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LoggingLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            Console.Write(String.Format("[{0,-5}] ", level.ToString() ));
            Console.ResetColor();
        }
    }

    public enum LoggingLevel
    {
        OFF = 0,
        ERROR = 1,
        INFO = 2,
        DEBUG = 3,
    }
}
