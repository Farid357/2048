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

        public void IncreaseNumber()
        {
            Number *= 2;
            _view.Show(Number);
        }

        public void Move(Vector2 position)
        {
            _view.Move(position);
        }

        public void Destroy()
        {
            _view.Destroy();
        }
    }
}