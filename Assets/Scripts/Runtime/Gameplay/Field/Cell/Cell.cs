using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class Cell : MonoBehaviour, ICell
    {
        public bool IsEmpty => Tile == null;

        public Vector2 Position => transform.position;

        public ITile Tile { get; private set; }

        public void PutTile(ITile tile)
        {
            if (!IsEmpty)
                throw new InvalidOperationException($"Cell already has tile!");

            Tile = tile ?? throw new ArgumentNullException(nameof(tile));
        }

        public void Clear()
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Cell already hasn't tile!");
            
            Tile = null;
        }
    }
}