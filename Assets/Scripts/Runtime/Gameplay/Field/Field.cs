using System;
using System.Linq;
using UnityEngine;

namespace Game.Gameplay
{
    public class Field : IField
    {
        private readonly ICell[,] _cells;
        private readonly ITileFactory _tileFactory;

        private bool _movedCells;
        
        public Field(ICell[,] cells, ITileFactory tileFactory)
        {
            _cells = cells ?? throw new ArgumentNullException(nameof(cells));
            _tileFactory = tileFactory ?? throw new ArgumentNullException(nameof(tileFactory));

            ICell cell = cells[0, 0];
            ICell secondCell = cells[3, 0];

            cell.PutTile(_tileFactory.Create(cell.Position, 2));
            secondCell.PutTile(_tileFactory.Create(secondCell.Position, 2));
        }

        public bool HasWinningTile => _cells.Cast<ICell>().ToList().Find(cell => cell.IsEmpty == false && cell.Tile.Number == 2048) != null;

        public void MoveCells(Vector2Int direction)
        {
            _movedCells = false;
            
            if (direction == Vector2Int.up)
            {
                for (int x = 0; x < _cells.GetLength(0); x++)
                {
                    for (int y = 1; y < _cells.GetLength(1); y++)
                    {
                        Vector2Int position = new Vector2Int(x, y);
                        TryMoveCell(position, -direction, y);
                    }
                }
            }

            if (direction == Vector2Int.down)
            {
                for (int x = 0; x < _cells.GetLength(0); x++)
                {
                    for (int y = _cells.GetLength(1) - 2; y >= 0; y--)
                    {
                        Vector2Int position = new Vector2Int(x, y);
                        TryMoveCell(position, -direction, _cells.GetLength(1) - y - 1);
                    }
                }
            }

            if (direction == Vector2Int.right)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    for (int x = _cells.GetLength(0) - 2; x >= 0; x--)
                    {
                        Vector2Int position = new Vector2Int(x, y);
                        TryMoveCell(position, direction, _cells.GetLength(0) - x - 1);
                    }
                }
            }

            if (direction == Vector2Int.left)
            {
                for (int y = 0; y < _cells.GetLength(1); y++)
                {
                    for (int x = 1; x < _cells.GetLength(0); x++)
                    {
                        Vector2Int position = new Vector2Int(x, y);
                        TryMoveCell(position, direction, x);
                    }
                }
            }
            
            if (_movedCells && TryGetEmptyCell(out ICell cell))
            {
                ITile tile = _tileFactory.Create(cell.Position);
                cell.PutTile(tile);
            }
        }

        private void TryMoveCell(Vector2Int position, Vector2Int direction, int maxSteps)
        {
            ICell currentCell = _cells[position.x, position.y];
            ICell target = null;

            if (currentCell.IsEmpty)
                return;

            for (int i = 0; i < maxSteps; i++)
            {
                position += direction;
                ICell nextCell = _cells[position.x, position.y];

                if (nextCell.IsEmpty)
                {
                    target = nextCell;
                }

                else if (nextCell.Tile.Number == currentCell.Tile.Number)
                {
                    target = nextCell;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (target == null)
                return;
            
            if (target.IsEmpty)
            {
                currentCell.Tile.Move(target.Position);
                target.PutTile(currentCell.Tile);
                currentCell.Clear();
            }
            else
            {
                Merge(currentCell, target);
            }
            
            _movedCells = true;
        }

        private bool TryGetEmptyCell(out ICell cell)
        {
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

            cell = null;
            return false;
        }

        private void Merge(ICell cell, ICell target)
        {
            cell.Tile.Destroy();
            cell.Clear();
            target.Tile.IncreaseNumber();
        }
    }
}