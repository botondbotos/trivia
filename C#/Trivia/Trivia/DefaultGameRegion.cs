namespace Trivia
{
    public class DefaultGameRegion : GameRegion
    {
        public DefaultGameRegion()
        : base(new DefaultQuestionFactory(), new DefaultCategorySelector(), new DefaultBoard())
        {
        }
    }
}