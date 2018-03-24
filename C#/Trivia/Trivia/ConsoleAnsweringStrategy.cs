namespace Trivia
{
    using System;
    using UglyTrivia;

    public class ConsoleAnsweringStrategy : IAnsweringStrategy
    {
        public bool IsNotWinner(Game game)
        {
            Console.WriteLine("Your answer: ");
            int next;
            while (!int.TryParse(Console.ReadLine(), out next))
            {
                Console.WriteLine("Must be number, try again");
            }

            return next == 7 ? game.WrongAnswer() : game.WasCorrectlyAnswered();
        }
    }
}