using UnityEngine;

namespace Game.Gameplay
{
    public class TileFactory : MonoBehaviour, ITileFactory
    {
        [SerializeField] private TileView _tilePrefab;
        [SerializeField] private Transform _parent;
        
        public ITile Create(Vector2 position)
        {
            ITileView view = Instantiate(_tilePrefab, position, Quaternion.identity, _parent);
            int number = Random.Range(0, 4) == 0 ? 2 : 4;
            return new Tile(number, view);
        }
    }
}