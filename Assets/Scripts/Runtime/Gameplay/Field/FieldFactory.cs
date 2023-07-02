using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class FieldFactory : MonoBehaviour
    {
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private RectTransform _content;
        [SerializeField] private TileFactory _tileFactory;

        public async Task<IField> Create(int width, int height)
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

            await Task.Delay(TimeSpan.FromSeconds(0.3f));
            return new Field(cells, _tileFactory);
        }
    }
}