namespace Trivia
{
    public interface ICategorySelector
    {
        QuestionCategory GetCategoryForField(int playerPlace);
    }
}