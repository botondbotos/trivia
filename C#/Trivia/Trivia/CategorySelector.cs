using System;

namespace UglyTrivia
{
    public class CategorySelector : ICategorySelector
    {
        private const int CategoryCount = 4;

        public string GetCategoryForField(int playerPlace)
        {
            switch (playerPlace % CategoryCount)
            {
                case 0: return "Pop";
                case 1: return "Science";
                case 2: return "Sports";
                case 3: return "Rock";
                default: throw new Exception("Invalid Category");
            }
        }
    }
}