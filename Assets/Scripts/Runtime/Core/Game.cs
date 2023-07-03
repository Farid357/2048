using System.Collections;
using System.Collections.Generic;
using Game.UI;
using Game.Loop;
using Game.Gameplay;
using Game.SceneManagement;
using SaveSystem;
using SaveSystem.Paths;
using DG.Tweening;
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
        
        [Header("UI")]
        [SerializeField] private UnityButton _menuButton;
        [SerializeField] private UnityButton _rollbackButton;
        [SerializeField] private UnityButton _restartButton;
        
        [Header("Scenes")]
        [SerializeField] private Scene _menu;
        [SerializeField] private Scene _game;
        
        private IGameLoopObjects _gameLoop;

        private IEnumerator Start()
        {
            _gameLoop = new GameLoopObjects();
            DOTween.Init();
            
            IScore score = new Score(_scoreView);
            ISaveStorage<int> recordStorage = new BinaryStorage<int>(new Path(nameof(BestScore)));
            IBestScore bestScore = new BestScore(score, recordStorage, _bestScoreView);
            ICell[,] cells = _cellsFactory.Create(width: 4, height: 4);

            yield return new WaitForSeconds(0.3f);

            ISaveStorage<Stack<FieldSnapshot>> snapshotsStorage = new BinaryStorage<Stack<FieldSnapshot>>(new Path(nameof(Field)));
            IFieldRollback field = new FieldRollback(new Field(cells, _tileFactory, score), snapshotsStorage);
            IGameLoopObject player = new Player(_playerInput, field);
            IGameLoopObject victory = new Victory(field, _victoryView);

            _gameLoop.Add(new GameLoopObjects(new List<IGameLoopObject>
            {
                player,
                victory,
                bestScore
            }));
            
            _rollbackButton.Subscribe(new RollbackButton(field));
            _menuButton.Subscribe(new SceneLoadButton(_menu));
            _restartButton.Subscribe(new RestartButton(snapshotsStorage, _game));
        }

        private void Update()
        {
            _gameLoop.Update(Time.deltaTime);
        }
    }
}