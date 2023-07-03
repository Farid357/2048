using UnityEngine;

namespace Game.Gameplay
{
    public interface IField : IReadOnlyField
    {
        void MoveCells(Vector2Int direction);

        void Load(FieldSnapshot snapshot);
        
        FieldSnapshot Save();
    }
}