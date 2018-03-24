using NUnit.Framework;

namespace Trivia.Tests
{
    [TestFixture]
    public class Categories
    {
        [Test]
        public void When_InDefaultOrJapanRegion_CategoriesAreRock() { }

        [Test]
        public void When_InIndiaRegion_CategoriesAreRock() { }

        [Test]
        public void When_InKoreaRegion_Fields5_13AreLiterature() { }
    }
}