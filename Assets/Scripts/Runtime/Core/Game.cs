using System.Collections;
using System.Collections.Generic;
using Game.Loop;
using Game.Gameplay;
using SaveSystem;
using SaveSystem.Paths;
using UnityEngine;

namespace Game.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private CellsFactory _cellsFactory;
        [SerializeField] private TileFactory _tileFactory;
        [SerializeField] private VictoryView _victoryView;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private BestScoreView _bestScoreView;
        
        private IGameLoopObjects _gameLoop;

        private IEnumerator Start()
        {
            _gameLoop = new GameLoopObjects();

            IScore score = new Score(_scoreView);
            ISaveStorage<int> recordStorage = new BinaryStorage<int>(new Path(nameof(BestScore)));
            IBestScore bestScore = new BestScore(score, recordStorage, _bestScoreView);
            ICell[,] cells = _cellsFactory.Create(width: 4, height: 4);

            yield return new WaitForSeconds(0.3f);

            IField field = new Field(cells, _tileFactory, score);
            IGameLoopObject player = new Player(_playerInput, field);
            IGameLoopObject victory = new Victory(field, _victoryView);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                victory,
                bestScore
            }));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}