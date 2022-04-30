
namespace RaceManager
{
    /// <summary>
    /// Logger
    /// </summary>
    public class RMLogger
    {
        private static Mutex mut = new Mutex();

        public LoggingLevel LogLevel;
        public string contextPrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="RMLogger"/> class.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="contextPrefix"></param>
        public RMLogger(LoggingLevel logLevel = LoggingLevel.DEBUG, string contextPrefix = "")
        {
            LogLevel = logLevel;
            this.contextPrefix = contextPrefix + ".";
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public void log(LoggingLevel level, string context, object message)
        {
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

        /// <summary>
        /// Formatting for writing in the console
        /// </summary>
        /// <param name="caller"></param>
        private static void WriteCaller(string caller)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int n = Allign(caller);
            string allign = caller + (new string(' ', n));
            Console.Write(String.Format($"[{allign}] "));
            Console.ResetColor();
        }

        /// <summary>
        /// Formatting alignement for writing in the console
        /// </summary>
        /// <param name="text">Text to format</param>
        /// <returns></returns>
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

        /// <summary>
        /// Level formatting for writing in the console
        /// </summary>
        /// <param name="level"></param>
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

    /// <summary>
    /// Level of logging
    /// </summary>
    public enum LoggingLevel
    {
        OFF = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        DEBUG = 4,
    }
}
