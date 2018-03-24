namespace UglyTrivia
{
    using System;

    public class ConsoleGameLogger : IGameLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}