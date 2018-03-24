using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionFactory : IQuestionFactory
    {
        private readonly IEnumerable<QuestionCategory> mCategories;

        private const int QuestionCount = 50;

        public QuestionFactory(IEnumerable<QuestionCategory> categories)
        {
            mCategories = categories.ToArray();
        }

        public List<LinkedList<string>> GenerateQuestionsForCategories()
        {
            return mCategories.Select(Dodo).ToList();
        }

        public LinkedList<string> Dodo(QuestionCategory category)
        {
            var questions = new LinkedList<string>();
            for (int i = 0; i < QuestionCount; i++)
            {
                questions.AddLast($"{category} Question " + i);
            }

            return questions;
        }
    }
}