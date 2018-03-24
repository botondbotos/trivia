namespace Trivia
{
    public class KoreaGameRegion : GameRegion
    {
        public KoreaGameRegion()
            : base(new DefaultQuestionFactory(), new KoreaCategorySelector(), new JapanBoard())
        {
        }
    }
}