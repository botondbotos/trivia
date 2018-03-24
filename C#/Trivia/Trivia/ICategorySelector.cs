namespace UglyTrivia
{
    public interface ICategorySelector
    {
        QuestionCategory GetCategoryForField(int playerPlace);
    }
}