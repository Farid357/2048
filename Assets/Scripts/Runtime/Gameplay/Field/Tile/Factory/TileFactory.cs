using UnityEngine;

namespace Game.Gameplay
{
    public class TileFactory : MonoBehaviour, ITileFactory
    {
        [SerializeField] private TileView _tilePrefab;
        [SerializeField] private Transform _parent;
        
        public ITile Create(Vector2 position)
        {
            int randomNumber = Random.Range(0, 4) <= 2 ? 2 : 4;
            return Create(position, randomNumber);
        }

        public ITile Create(Vector2 position, int number)
        {
            ITileView view = Instantiate(_tilePrefab, position, Quaternion.identity, _parent);
            view.Show(number);
            return new Tile(number, view);
        }
    }
}