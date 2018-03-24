namespace Trivia
{
    public class DefaultQuestionFactory : QuestionFactory
    {
        public DefaultQuestionFactory()
            : base(
                new[]
                {
                    QuestionCategory.Pop,
                    QuestionCategory.Science,
                    QuestionCategory.Sports,
                    QuestionCategory.Rock,
                })
        {
        }
    }
}