namespace Trivia
{
    public interface IGameRegion
    {
        IQuestionFactory QuestionFactory { get; }
        ICategorySelector CategorySelector { get; }
        IBoard Board { get; }
    }
}