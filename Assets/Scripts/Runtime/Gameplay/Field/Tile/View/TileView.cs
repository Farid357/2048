using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay
{
    public class TileView : MonoBehaviour, ITileView
    {
        [SerializeField] private Text _number;
        [SerializeField] private Image _image;
        [SerializeField] private Color[] _colors;
        
        public void Show(int number)
        {
            _number.text = number.ToString();
            int s = 2;
            int pow = 1;

            while (number > s)
            {
                pow += 1;    
                s *= 2;
            }

            _image.color = _colors[pow];
        }

        public void Move(Vector2 position)
        {
            //TODO DOTween based movement
            transform.position = position;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}