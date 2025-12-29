using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Board Board;
    public Pieces PiecePrefab;

    public Vector3 GetPositionOfCell(Vector2Int cell)
    {
        return Board.GetPosition(cell);
    }

    public BoardCell GetCell(Vector2Int cell)
    {
        return Board.GetCell(cell);
    }

    public void FillColor(List<Vector2Int> cells, bool canMove)
    {
        Board.FillColor(cells, canMove);
    }
}