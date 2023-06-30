using System.Collections.Generic;
using Game.GameLoop;
using Game.Gameplay;
using UnityEngine;

namespace Game.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private FieldFactory _fieldFactory;

        private IGameLoopObjects _gameLoop;

        private async void Awake()
        {
            _gameLoop = new GameLoopObjects();
            _playerInput.Init(Camera.main);

            IField field = await _fieldFactory.Create(width: 4, height: 4);
            IGameLoopObject player = new Player(_playerInput, field);

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