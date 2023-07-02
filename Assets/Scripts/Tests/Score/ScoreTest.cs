using Game.Gameplay;
using Game.Loop;
using NUnit.Framework;

namespace Game.Tests
{
    [TestFixture]
    public class ScoreTest
    {
        [Test]
        public void AddsCountCorrectly()
        {
            IScore score = new Score(new FakeScoreView());
            const int scoreCount = 10;
            score.Add(scoreCount);
            Assert.That(score.Count == scoreCount);
        }
    }
}