using Game.Gameplay;
using UnityEngine;

namespace Game.Tests
{
    public class FakeTileView : ITileView
    {
        public int Number { get; private set; }
        
        public bool WasMoved { get; private set; }
        
        public bool IsDestroyed { get; private set; }
        
        public void Show(int number)
        {
            Number = number;
        }

        public void Move(Vector2 position)
        {
            WasMoved = true;
        }

        public void Destroy()
        {
            IsDestroyed = true;
        }

    }
}