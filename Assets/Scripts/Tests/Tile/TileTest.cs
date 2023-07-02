using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    [TestFixture]
    public class TileTest
    {
        [Test]
        public void IncreasesNumberCorrectly()
        {
            const int startNumber = 4;
            ITile tile = new Tile(startNumber, new FakeTileView());
            tile.IncreaseNumber();
            Assert.That(tile.Number == startNumber * 2);
        }
        
        [Test]
        public void ChangesView()
        {
            var tileView = new FakeTileView();
            ITile tile = new Tile(2, tileView);
          
            tile.IncreaseNumber();
            Assert.That(tileView.Number == 4);
            
            tile.Move(Vector2.down);
            Assert.That(tileView.WasMoved);
            
            tile.Destroy();
            Assert.That(tileView.IsDestroyed);
        }
    }
}