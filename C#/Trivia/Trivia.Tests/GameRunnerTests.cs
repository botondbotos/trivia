using UglyTrivia;

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

                    var dice = new Dice();
                    var consoleGameLogger = new ConsoleGameLogger();
                    var categorySelector = new CategorySelector();
                    var questionFactory = new QuestionFactory();
                    var game = new Game(consoleGameLogger, categorySelector, questionFactory);
                    var random = new Random(testRunId);
                    var randomAnsweringStrategy = new RandomAnsweringStrategy(random);

                    var gameRunner = new GameRunner(dice, randomAnsweringStrategy, random, game);
                    gameRunner.Start();

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
                var dice = new Dice();
                var consoleGameLogger = new ConsoleGameLogger();
                var categorySelector = new CategorySelector();
                var questionFactory = new QuestionFactory();
                var game = new Game(consoleGameLogger, categorySelector, questionFactory);
                var random = new Random(seed);
                var randomAnsweringStrategy = new RandomAnsweringStrategy(random);

                var gameRunner = new GameRunner(dice, randomAnsweringStrategy, random, game);

                // Act
                gameRunner.Start();

                // Assert
                var actualGameOutput = gameOutputStringBuilder.ToString();
                var expectedGameOutput = File.ReadAllText($@"c:\TestData\GoldenData_{seed}.txt");
                actualGameOutput.Should().BeEquivalentTo(expectedGameOutput);
            }
        }
    }
}
