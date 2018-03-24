using System.Collections.Generic;

namespace Trivia
{
    public interface IQuestionFactory
    {
        List<LinkedList<string>> GenerateQuestionsForCategories();
    }
}
