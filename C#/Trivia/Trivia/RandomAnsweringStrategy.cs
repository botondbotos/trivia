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
            return this.rand.Next(9) == 7
                ? game.WrongAnswer()
                : game.WasCorrectlyAnswered();
        }
    }
}