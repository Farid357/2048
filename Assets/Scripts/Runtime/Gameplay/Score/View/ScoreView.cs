using TMPro;
using UnityEngine;

namespace Game.Gameplay
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Show(int score)
        {
            _text.text = score.ToString();
        }
    }
}