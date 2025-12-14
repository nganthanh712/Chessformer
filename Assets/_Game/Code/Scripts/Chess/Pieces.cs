using System;
using UnityEngine;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
    private Chess _chess { get; set; }
    private BoardCell _cell { get; set; }

    public Vector2Int[] Directions = new[]
    {
        Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
    };

    private Image _icon;

    private void Awake()
    {
        _icon = GetComponent<Image>();
    }

    public void Init(PieceData data)
    {
        SetData(data);
    }

    private void SetData(PieceData state)
    {
        if (state == null) return;

        _chess = state.ChessData;

        Debug.LogError($"Cell {state.BoardCellVector}");
        
        _cell = GameController.Ins.BoardManager.GetCell(state.BoardCellVector);
        _icon.sprite = LevelController.Ins.LevelDatabase.GetSprite(_chess);

        Debug.LogError($"ChessName: {_chess.ToString()} - {_cell.Coordinates}");

        Spawn(state.BoardCellVector);
    }

    private void Spawn(Vector2Int cell)
    {
        if (_cell != null)
        {
            _cell.Piece = null;
        }

        _cell.Coordinates = cell;
        _cell.Piece = this;
        
        transform.SetParent(_cell.transform);
        transform.position = GameController.Ins.BoardManager.GetPositionOfCell(cell);
    }
}