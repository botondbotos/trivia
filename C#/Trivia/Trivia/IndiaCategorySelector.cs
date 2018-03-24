using System;

namespace Trivia
{
    public class IndiaCategorySelector : ICategorySelector
    {
        private const int CategoryCount = 4;

        QuestionCategory ICategorySelector.GetCategoryForField(int playerPlace)
        {
            switch (playerPlace % CategoryCount)
            {
                case 0: return QuestionCategory.Pop;
                case 1: return QuestionCategory.Science;
                case 2: return QuestionCategory.Sports;
                case 3: return QuestionCategory.History;
                default: throw new Exception("Invalid Category");
            }
        }
    }
}