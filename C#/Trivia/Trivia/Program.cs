using UglyTrivia;

namespace Trivia
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var rand = args.Length > 0 && int.TryParse(args[0], out var seed)
                ? new Random(seed)
                : new Random();

            var dice = new Dice();
            var consoleGameLogger = new ConsoleGameLogger();
            var categorySelector = new CategorySelector();
            var questionFactory = new QuestionFactory();

            var game = new Game(consoleGameLogger, categorySelector, questionFactory);
            var randomAnsweringStrategy = new ConsoleAnsweringStrategy();

            var gameRunner = new GameRunner(dice, randomAnsweringStrategy, rand, game);

            gameRunner.Start();
        }
    }
}
