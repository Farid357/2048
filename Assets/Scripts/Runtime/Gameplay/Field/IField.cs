using UnityEngine;

namespace Game.Gameplay
{
    public interface IField
    {
        void MoveCells(Vector2Int direction);
    }
}