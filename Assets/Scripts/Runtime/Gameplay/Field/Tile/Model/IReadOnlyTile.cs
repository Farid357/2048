using UnityEngine;

namespace Game.Gameplay
{
    public interface IReadOnlyTile
    {
        int Number { get; }

        Vector2 Position { get; }
    }
}