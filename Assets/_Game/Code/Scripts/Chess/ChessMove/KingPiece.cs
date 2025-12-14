using System.Collections.Generic;
using UnityEngine;

public class KingPiece : Pieces
{
    private List<Vector2Int> _moves = new();

    public List<Vector2Int> Moves => _moves;

    public Vector2Int[] _directions = 
    {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left,
        Vector2Int.one, -Vector2Int.one, new (1, -1), new (-1, 1)
    };

    public List<Vector2Int> GetMove(Vector2Int cell)
    {
        for (int i = 0; i<_directions.Length; i++)
        {
            Vector2Int cellToMove = cell + _directions[i];

            if (HasObstacle(cellToMove))
            {
                continue;
            }
            
            Moves.Add(cellToMove);
        }

        return Moves;
    }

    private bool HasObstacle(Vector2Int cellToMove)
    {
        BoardCell cell = GameController.Ins.BoardManager.GetCell(cellToMove);
        
        if (cell != null && cell.IsOccupied)
        {
            return true;
        }
        
        return false;
    }
}