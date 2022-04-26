
namespace RaceManager
{
    public class RMLogger
    {
        private static Mutex mut = new Mutex();

        public LoggingLevel LogLevel;
        public string contextPrefix;



        public RMLogger(LoggingLevel logLevel = LoggingLevel.DEBUG, string contextPrefix = "")
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RMLogger"/> class.
            /// </summary>
            LogLevel = logLevel;
            this.contextPrefix = contextPrefix + ".";
        }

        public void log(LoggingLevel level, string context, object message)
        {
            /// <summary>
            /// Logs a message.
            /// </summary>
            if (level <= LogLevel && level != LoggingLevel.OFF)
            {
                mut.WaitOne();
                if (Console.Out != null) Console.Out.Flush();
                Console.Write(String.Format("{0,-16} | ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                WriteLevel(level);
                WriteCaller($"{contextPrefix}{context}");
                Console.Write(": ");
                Console.WriteLine(String.Format("{1}", context, message));
                Console.ResetColor();
                mut.ReleaseMutex();
            }
        }

        private static void WriteCaller(string caller)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int n = Allign(caller);
            string allign = caller + (new string(' ', n));
            Console.Write(String.Format($"[{allign}] "));
            Console.ResetColor();
        }

        private static int Allign(string text)
        {
            if (text.Length <= 24)
            {
                return 25 - text.Length;
            }
            else if(text.Length <= 32)
            {
                return 32 - text.Length;
            }
            else if (text.Length <= 40)
            {
                return 45 - text.Length;
            }

            return 0;
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
                case LoggingLevel.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LoggingLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.Write(String.Format("[{0,-5}] ", level.ToString()));
            Console.ResetColor();
        }
    }

    public enum LoggingLevel
    {
        OFF = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        DEBUG = 4,
    }
}
