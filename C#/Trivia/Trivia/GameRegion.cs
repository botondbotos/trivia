namespace Trivia
{
    public class GameRegion : IGameRegion
    {
        public IQuestionFactory QuestionFactory { get; }
        public ICategorySelector CategorySelector { get; }
        public IBoard Board { get; }

        public GameRegion(IQuestionFactory questionFactory, ICategorySelector defaultCategorySelector, IBoard board)
        {
            QuestionFactory = questionFactory;
            CategorySelector = defaultCategorySelector;
            Board = board;
        }
    }
}