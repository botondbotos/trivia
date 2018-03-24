using System;

namespace Trivia
{
    public class KoreaCategorySelector : ICategorySelector
    {
        private const int CategoryCount = 4;

        public QuestionCategory GetCategoryForField(int playerPlace)
        {
            if (playerPlace == 5 || playerPlace == 13) return QuestionCategory.Literature;

            switch (playerPlace % CategoryCount)
            {
                case 0: return QuestionCategory.Pop;
                case 1: return QuestionCategory.Science;
                case 2: return QuestionCategory.Sports;
                case 3: return QuestionCategory.Rock;
                default: throw new Exception("Invalid Category");
            }
        }
    }
}