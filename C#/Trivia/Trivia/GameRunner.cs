namespace Trivia
{
    using System;
    using UglyTrivia;

    public class GameRunner
    {
        private static bool notAWinner;

        public static void Main(string[] args)
        {
            Game aGame = new Game(new ConsoleGameLogger(), new CategorySelector(), new QuestionFactory());

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            var rand = args.Length > 0 && int.TryParse(args[0], out var seed) ? new Random(seed) : new Random();

            do
            {
                aGame.MovePlayer(rand.Next(5) + 1);

                notAWinner = rand.Next(9) == 7 ? aGame.WrongAnswer() : aGame.WasCorrectlyAnswered();
            }
            while (notAWinner);
        }
    }
}
