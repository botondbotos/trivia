using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Trivia.UnitTests
{
    public class GameRunnerTests
    {
        //[Test]
        //public void GenerateTestData()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        using (var gameOutput = File.CreateText($@"TestData\GoldenData_{i}.txt"))
        //        {
        //            Console.SetOut(gameOutput);
        //            GameRunner.Main(new[] { i.ToString() });

        //            gameOutput.Flush();
        //        }
        //    }
        //}

        [Test]
        public void GenerateGoldenSource([Range(0, 99)]int seed)
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
                var expectedGameOutput = File.ReadAllText($@"TestData\GoldenData_{seed}.txt");
                actualGameOutput.Should().BeEquivalentTo(expectedGameOutput);
            }
        }
    }
}
