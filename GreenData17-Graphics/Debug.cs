using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDWGL
{
    public class Debug
    {
        public static void Log(string msg) { ConsoleWrite(ConsoleColor.White,      " LOG   ", msg); }
        public static void LogInfo(string msg) { ConsoleWrite(ConsoleColor.Cyan,   " INFO  ", msg); }
        public static void LogWarn(string msg) { ConsoleWrite(ConsoleColor.Yellow, " WARN  ", msg); }
        public static void LogError(string msg) { ConsoleWrite(ConsoleColor.Red,   " ERROR ", msg); }

        static void ConsoleWrite(ConsoleColor color, string prefix, string msg)
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{prefix}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = color;
            Console.WriteLine($" {msg}");
        }
    }
}
