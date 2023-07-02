using Game.SceneManagement;
using Game.UI;
using UnityEngine;

namespace Game.Core
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private UnityButton _playButton;
        [SerializeField] private Scene _game;
        
        private void Awake()
        {
            _playButton.Subscribe(new SceneLoadButton(_game));
        }
    }
}