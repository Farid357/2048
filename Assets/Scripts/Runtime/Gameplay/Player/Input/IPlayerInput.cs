using UnityEngine;

namespace Game.Gameplay
{
    public interface IPlayerInput
    {
        Vector2 SwipeDirection { get; }
    }
}