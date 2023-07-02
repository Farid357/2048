using UnityEngine;

namespace Game.Gameplay
{
    public class VictoryView : MonoBehaviour, IVictoryView
    {
        [SerializeField] private Window _window;
        
        public void ShowVictory()
        {
            _window.Open();
        }
    }
}