using System;
using Game.Tools;
using UnityEngine;

namespace Game.Gameplay
{
    public class Tile : ITile
    {
        private readonly ITileView _view;

        public Tile(int number, ITileView view)
        {
            Number = number.ThrowIfLessThanOrEqualsToZeroException();
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int Number { get; private set; }

        public Vector2 Position { get; private set; }

        public void IncreaseNumber()
        {
            Number *= 2;
            _view.Show(Number);
        }

        public void Move(Vector2 position)
        {
            if (Position == position)
                throw new ArgumentOutOfRangeException($"Tile already has same position!");

            _view.Move(position);
            Position = position;
        }

        public void Destroy()
        {
            _view.Destroy();
        }
    }
}