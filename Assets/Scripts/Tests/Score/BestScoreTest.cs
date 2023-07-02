using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    [TestFixture]
    public class BestScoreTest
    {
        [Test]
        public void RecordCorrectly()
        {
            IScore score = new Score(new FakeScoreView());
            IBestScore bestScore = new BestScore(score, new FakeStorage<int>(), new FakeBestScoreView());
            
            const int scoreCount = 10;
            score.Add(scoreCount);
            bestScore.Update(0.2f);
            Assert.That(bestScore.Record == scoreCount);
        }
    }
}