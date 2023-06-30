using UnityEngine;

namespace Game.Gameplay
{
    public interface ITile : IReadOnlyTile
    {
        void IncreaseNumber();

        void Move(Vector2 position);

        void Destroy();
    }
}