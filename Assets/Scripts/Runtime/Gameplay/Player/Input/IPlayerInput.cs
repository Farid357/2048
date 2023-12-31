using UnityEngine;

namespace Game.Gameplay
{
    public interface IPlayerInput
    {
        Vector2Int SwipeDirection { get; }
        
        bool IsUp { get; }

        void ResetSwipeAll();
    }
}