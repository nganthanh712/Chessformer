using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : Pieces
{
    private BoardCell _cell;

    private readonly List<Vector2Int> _moves = new();

    public List<Vector2Int> Moves => _moves;

    private readonly int[] colDirections = { -1, 0, -1, -1, 1, -1, 0, 1 };
    private readonly int[] rowDirections = { 1, 1, 1, 0, 0, -1, -1, -1 };

    private int[,] _boardSize;

    public void GetCell(BoardCell curCell)
    {
        _cell = curCell;
    }

    private List<Vector2Int> GetMove()
    {
        _boardSize = GameController.Ins.BoardManager.Board.BoardSize;

        int cols = _boardSize.GetLength(0); //16
        int rows = _boardSize.GetLength(1);
        
        Debug.LogError($"Row {rows}, Col {cols}");

        for (int dir = 0; dir < 8; dir++)
        {
            int rowDir = rowDirections[dir];
            int colDir = colDirections[dir];

            for (int step = 1; step < Mathf.Max(rows, cols); step++)
            {
                Vector2Int cellToMove = new(_cell.Coordinates.x + (colDir * step),
                    _cell.Coordinates.y + (rowDir * step));
                
                Debug.LogError($"Cell {_cell.Coordinates.x} - {_cell.Coordinates.y} - {dir}");
                Debug.LogError($"CellToMove {cellToMove.x} - {cellToMove.y}");

                if (cellToMove.x < 0 || cellToMove.x >= cols ||
                    cellToMove.y < 0 || cellToMove.y >= rows)
                {
                    Debug.Log($"Out of bounds: ({cellToMove.x}, {cellToMove.y})");

                }

                BoardCell cell = GameController.Ins.BoardManager.Board.GetCell(cellToMove);

                // Kiểm tra có nằm trong bàn cờ không
                if (cell != default && !cell.IsOccupied)
                {
                    Moves.Add(cellToMove);
                }
                // else if (IsEnemyPiece(targetSquare, isWhite))
                // {
                //     validMoves.Add(new Position(newRow, newCol));
                //     break;
                // }
                // Có quân ta - dừng lại
                else
                {
                    break;
                }
            }
        }
        
        GameController.Ins.BoardManager.FillColor(Moves, true);

        return Moves;
    }

    protected override void OnClickPiece()
    {
        Debug.LogError("OnClick Queen 2");

        GetMove();
    }
}