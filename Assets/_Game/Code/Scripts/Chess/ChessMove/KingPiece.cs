using System.Collections.Generic;
using UnityEngine;

public class KingPiece : Pieces
{
    private BoardCell _cell;
    private List<Vector2Int> _moves = new();

    public List<Vector2Int> Moves => _moves;
    
    private List<BoardCell> _pieceCanEat = new();
    public List<BoardCell> PieceCanEat => _pieceCanEat;

    public Vector2Int[] _directions = 
    {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left,
        Vector2Int.one, -Vector2Int.one, new (1, -1), new (-1, 1)
    };
    
    public void GetCell(BoardCell curCell)
    {
        _cell = curCell;
    }

    private List<Vector2Int> GetMove()
    {
        for (int i = 0; i<_directions.Length; i++)
        {
            Vector2Int cellToMove = _cell.Coordinates+ _directions[i];

            BoardCell cell = GameController.Ins.BoardManager.GetCell(cellToMove);

            if (cell == null || cell.IsOccupied)
            {
                continue;
            }
            
            Moves.Add(cellToMove);
        }
        
        GameController.Ins.BoardManager.FillColor(Moves, true);

        return Moves;
    }

    protected override void OnClickPiece()
    {
        Debug.LogError("OnClick King 2");

        GetMove();
    }
}