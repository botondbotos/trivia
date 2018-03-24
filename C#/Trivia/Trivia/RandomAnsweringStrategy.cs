namespace Trivia
{
    using System;
    using UglyTrivia;

    public class RandomAnsweringStrategy : IAnsweringStrategy
    {
        private readonly Random rand;

        public RandomAnsweringStrategy(Random rand)
        {
            this.rand = rand;
        }

        public bool IsNotWinner(Game game)
        {
            return rand.Next(9) == 7
                ? game.WrongAnswer()
                : game.WasCorrectlyAnswered();
        }
    }
}