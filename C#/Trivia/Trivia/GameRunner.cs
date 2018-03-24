namespace Trivia
{
    using System;
    using UglyTrivia;

    public class GameRunner
    {
        private static bool notAWinner;

        public static void Main(string[] args)
        {
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");

            var rand = args.Length > 0 && int.TryParse(args[0], out var seed) ? new Random(seed) : new Random();

            do
            {
                aGame.roll(rand.Next(5) + 1);

                notAWinner = rand.Next(9) == 7 ? aGame.wrongAnswer() : aGame.wasCorrectlyAnswered();
            } while (notAWinner);
        }
    }
}
