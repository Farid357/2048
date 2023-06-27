using System.Collections.Generic;
using Game.GameLoop;
using Game.Gameplay;
using UnityEngine;

namespace Game.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        
        private IGameLoopObjects _gameLoop;
        
        private void Awake()
        {
            _gameLoop = new GameLoopObjects();
            _playerInput.Init(Camera.main);
            
            IGameLoopObject player = new Player(_playerInput);
            
            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player
            }));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}