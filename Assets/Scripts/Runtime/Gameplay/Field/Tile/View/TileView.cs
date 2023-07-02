using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay
{
    public class TileView : MonoBehaviour, ITileView
    {
        [SerializeField] private TMP_Text _number;
        [SerializeField] private Image _image;
        [SerializeField] private Color[] _colors;

        private void OnEnable()
        {
            Vector3 startScale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(startScale, 0.3f);
        }

        public void Show(int number)
        {
            _number.text = number.ToString();
            _number.color = number > 2048 ? Color.black : _number.color;

            if (number == 2)
                return;
            
            int pow = 1;

            while (number > Mathf.Pow(2, pow))
            {
                pow += 1;
            }

            Vector3 startScale = transform.localScale;
            transform.DOScale(transform.localScale * 1.2f, 0.2f).OnComplete(() => transform.localScale = startScale);
            _image.color = number <= 2048 ? _colors[pow - 1] : Color.black;
        }

        public void Move(Vector2 position)
        {
            transform.DOMove(position, 0.2f).SetEase(Ease.InQuad);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}