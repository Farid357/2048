using UnityEngine;

namespace Game.Gameplay
{
    public interface ITileFactory
    {
        ITile Create(Vector2 position);
    }
}