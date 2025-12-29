using System;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public BoardRow[] Rows { get; private set; }
    public BoardCell[] Cells { get; private set; }

    public BoardCell CellPrefab;

    public int[,] BoardSize;

    public int Size => Cells.Length;
    public int RowCount => Rows.Length;
    public int ColumnCount => Size / RowCount;

    private void Awake()
    {
        Rows = GetComponentsInChildren<BoardRow>();
        Cells = GetComponentsInChildren<BoardCell>();

        BoardSize = new int[RowCount, ColumnCount];
    }

    private void Start()
    {
        InitCell();
    }

    private void InitCell()
    {
        for (int y = 0; y < Rows.Length; y++)
        {
            for (int x = 0; x < Rows[y].Cells.Length; x++)
            {
                Rows[y].Cells[x].Coordinates = new Vector2Int(x, y);
            }
        }
    }

    public Vector3 GetPosition(Vector2Int coordinates)
    {
        return Rows[coordinates.y].Cells[coordinates.x].transform.position;
    }

    public BoardCell GetCell(Vector2Int coordinates)
    {
        if (coordinates.y < 0 || coordinates.y >= Rows.Length )
        {
            return default;
        }

        if (coordinates.x < 0 || coordinates.x >= Rows[coordinates.y].Cells.Length)
        {
            return default;
        }

        return Rows[coordinates.y].Cells[coordinates.x];
    }

    public void FillColor(List<Vector2Int> moves, bool canMove)
    {
        foreach (Vector2Int move in moves)
        {
            Rows[move.y].Cells[move.x].SetStateCanMove(canMove);
        }
    }
}