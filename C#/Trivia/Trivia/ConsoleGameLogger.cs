using System;

namespace Trivia
{
    public class ConsoleGameLogger : IGameLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}