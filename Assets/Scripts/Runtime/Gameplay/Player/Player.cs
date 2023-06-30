using System;
using Game.GameLoop;
using UnityEngine;

namespace Game.Gameplay
{
    public class Player : IGameLoopObject
    {
        private readonly IPlayerInput _input;
        private readonly IField _field;

        public Player(IPlayerInput input, IField field)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _field = field ?? throw new ArgumentNullException(nameof(field));
        }

        public void Update(float deltaTime)
        {
            if (_input.IsSwiping)
            {
                Debug.Log(_input.SwipeDirection);
                _field.MoveCells(_input.SwipeDirection);
            }
        }
    }
}