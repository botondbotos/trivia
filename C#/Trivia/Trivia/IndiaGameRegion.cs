namespace Trivia
{
    public class IndiaGameRegion : GameRegion
    {
        public IndiaGameRegion()
            : base(new DefaultQuestionFactory(), new IndiaCategorySelector(), new DefaultBoard())
        {
        }
    }
}