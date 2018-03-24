namespace Trivia.UnitTests
{
    using System;
    using System.IO;
    using System.Text;

    using FluentAssertions;

    using NUnit.Framework;

    public class GameRunnerTests
    {
        private const string TestDataPath = @"c:\TestData\";

        [Test]
        public void GenerateTestData([Range(0, 99)] int testRunId)
        {
            if (!Directory.Exists(TestDataPath))
            {
                Directory.CreateDirectory(TestDataPath);
            }

            var filePath = Path.Combine(TestDataPath, $@"GoldenData_{testRunId}.txt");
            if (!File.Exists(filePath))
            {
                using (var gameOutput = File.CreateText(filePath))
                {
                    Console.SetOut(gameOutput);
                    GameRunner.Main(new[] { testRunId.ToString() });

                    gameOutput.Flush();
                }

                Assert.Pass("Master data file created successfully.");
            }
            else
            {
                Assert.Pass("Master data already exists.");
            }
        }

        [Test]
        public void CompareOutputAgainstGoldenSource([Range(0, 99)]int seed)
        {
            // Arrange
            var gameOutputStringBuilder = new StringBuilder();
            using (var gameOutput = new StringWriter(gameOutputStringBuilder))
            {
                Console.SetOut(gameOutput);

                // Act
                GameRunner.Main(new[] { seed.ToString() });

                // Assert
                var actualGameOutput = gameOutputStringBuilder.ToString();
                var expectedGameOutput = File.ReadAllText($@"c:\TestData\GoldenData_{seed}.txt");
                actualGameOutput.Should().BeEquivalentTo(expectedGameOutput);
            }
        }
    }
}
