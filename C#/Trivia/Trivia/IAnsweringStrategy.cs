namespace Trivia
{
    using UglyTrivia;

    public interface IAnsweringStrategy
    {
        bool IsNotWinner(Game game);
    }
}