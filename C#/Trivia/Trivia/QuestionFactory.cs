namespace UglyTrivia
{
    using System.Collections.Generic;

    public class QuestionFactory : IQuestionFactory
    {
        private const int QuestionCount = 50;

        public LinkedList<string> GenerateQuestionsForCategory(string category)
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