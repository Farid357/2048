using TMPro;
using UnityEngine;

namespace Game.Gameplay
{
    public class BestScoreView : MonoBehaviour, IBestScoreView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Show(int record)
        {
            _text.text = record.ToString();
        }
    }
}