using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CellsFactory : MonoBehaviour
    {
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private RectTransform _content;

        public ICell[,] Create(int width, int height)
        {
            ICell[,] cells = new ICell[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    ICell cell = Instantiate(_cellPrefab, _content.transform);
                    cells[x, y] = cell;
                }
            }

            return cells;
        }
    }
}