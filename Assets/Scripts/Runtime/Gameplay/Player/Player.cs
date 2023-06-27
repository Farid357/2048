using System;
using Game.GameLoop;

namespace Game.Gameplay
{
    public class Player : IGameLoopObject
    {
        private readonly IPlayerInput _input;
        
        public Player(IPlayerInput input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public void Update(float deltaTime)
        {
        }
    }
}