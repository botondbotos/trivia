using NUnit.Framework;

namespace Trivia.Tests
{
    public class BoardSizes
    {
        [Test]
        public void When_InDefaultOrIndiaRegion_BoardSizeIs12() { }

        [Test]
        public void When_InJapanKoreaRegion_BoardSizeIs16() { }
    }
}