using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    public BoardRow[] Rows { get; private set; }
    public BoardCell[] Cells { get; private set; }

    public BoardCell CellPrefab;
   
    public int Size => Cells.Length;
    public int RowCount => Rows.Length;
    public int ColumnCount => Cells.Length;
    
    private void Awake()
    {
        Rows = GetComponentsInChildren<BoardRow>();
        Cells = GetComponentsInChildren<BoardCell>();
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
}