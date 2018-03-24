using System.Collections.Generic;

namespace UglyTrivia
{
    public interface IQuestionFactory
    {
        LinkedList<string> GenerateQuestionsForCategory(QuestionCategory category);
    }
}
