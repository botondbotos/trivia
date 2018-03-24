namespace Trivia
{
    using System;

    public interface IDice
    {
        int Roll(Random rand);
    }

    public class Dice : IDice
    {
        public int Roll(Random rand)
        {
            return rand.Next(5) + 1;
        }
    }
}