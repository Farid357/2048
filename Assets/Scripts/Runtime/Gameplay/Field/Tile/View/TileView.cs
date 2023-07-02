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
            int pow = 1;

            while (number > Mathf.Pow(2, pow))
            {
                pow += 1;
            }

            _image.color = _colors[pow - 1];
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