using System.Collections.Generic;
using Game.Loop;
using Game.Gameplay;
using UnityEngine;

namespace Game.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private FieldFactory _fieldFactory;
        [SerializeField] private VictoryView _victoryView;
        
        private IGameLoopObjects _gameLoop;

        private async void Awake()
        {
            _gameLoop = new GameLoopObjects();

            IField field = await _fieldFactory.Create(width: 4, height: 4);
            IGameLoopObject player = new Player(_playerInput, field);
            IGameLoopObject victory = new Victory(field, _victoryView);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                victory
            }));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}