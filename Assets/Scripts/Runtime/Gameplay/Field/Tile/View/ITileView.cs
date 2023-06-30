using UnityEngine;

namespace Game.Gameplay
{
    public interface ITileView
    {
        void Show(int number);

        void Move(Vector2 position);
        
        void Destroy();
    }
}