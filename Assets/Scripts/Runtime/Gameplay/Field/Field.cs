using System;
using Game.Tools;
using UnityEngine;

namespace Game.Gameplay
{
    public class Field : IField
    {
        private readonly ICell[,] _cells;
        private readonly ITileFactory _tileFactory;

        public Field(ICell[,] cells, ITileFactory tileFactory)
        {
            _cells = cells ?? throw new ArgumentNullException(nameof(cells));
            _tileFactory = tileFactory ?? throw new ArgumentNullException(nameof(tileFactory));

            ICell cell = cells[0, 0];
            ICell secondCell = cells[3, 0];
            Debug.Log(cell.Position);
            Debug.Log(secondCell.Position);
        
            cell.PutTile(_tileFactory.Create(cell.Position));
            secondCell.PutTile(_tileFactory.Create(secondCell.Position));
        }

        public void MoveCells(Vector2Int direction)
        {
            bool isHorizontal = direction.IsHorizontal();
            bool isInverted = direction.x < 0 || direction.y < 0;
            int dimension = isHorizontal ? 0 : 1;

            if (isInverted)
            {
                for (int i = _cells.GetLength(dimension) - 1; i > 0; i--)
                {
                    Move(direction, isHorizontal, i);
                }
            }
            
            else
            {
                for (int i = 0; i < _cells.GetLength(dimension) - 1; i++)
                {
                    Move(direction, isHorizontal, i);
                }
            }
        }

        private void Move(Vector2Int direction, bool isHorizontal, int index)
        {
            Vector2Int position = isHorizontal ? new Vector2Int(index, 0) : new Vector2Int(0, index);
            Vector2Int nextCellPosition = position + direction;

            ICell currentCell = _cells[position.x, position.y];
            ICell nextCell = _cells[nextCellPosition.x, nextCellPosition.y];

            if (currentCell.IsNotEmpty())
            {
                if (nextCell.IsEmpty)
                {
                    currentCell.Tile.Move(nextCell.Tile.Position);
                    currentCell.Clear();
                }
                else
                {
                    Merge(currentCell, nextCell);
                }

                if (TryGetEmptyCell(out ICell cell))
                {
                    ITile tile = _tileFactory.Create(cell.Position);
                    cell.PutTile(tile);
                }
            }
        }

        private bool TryGetEmptyCell(out ICell cell)
        {
            cell = null;
            
            for (int x = 0; x < _cells.GetLength(0); x++)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    if (_cells[x, y].IsEmpty)
                    {
                        cell = _cells[x, y];
                        return true;
                    }
                }
            }

            return false;
        }

        private void Merge(ICell firstCell, ICell secondCell)
        {
            firstCell.Tile.Destroy();
       //     firstCell.Clear();
            secondCell.Tile.IncreaseNumber();
        }
    }
}