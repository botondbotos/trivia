namespace Trivia
{
    public interface IAnsweringStrategy
    {
        bool IsNotWinner(Game game);
    }
}