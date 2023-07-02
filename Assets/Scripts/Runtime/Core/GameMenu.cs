using System;
using UnityEngine;
using Game.UI;
using Game.SceneManagement;

namespace Game.Core
{
    public class GameMenu : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private UnityButton _menuButton;
        [SerializeField] private UnityButton _restartButton;
        
        [Header("Scenes")]
        [SerializeField] private Scene _menu;
        [SerializeField] private Scene _game;
        
        private void Awake()
        {
            _menuButton.Subscribe(new SceneLoadButton(_menu));
            _restartButton.Subscribe(new SceneLoadButton(_game));
        }
    }
}