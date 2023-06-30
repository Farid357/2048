using UnityEngine;

namespace Game.Gameplay
{
    public interface ICell
    {
        bool IsEmpty { get; }

        Vector2 Position { get; }
    
        ITile Tile { get; }

        void PutTile(ITile tile);

        void Clear();
    }
}