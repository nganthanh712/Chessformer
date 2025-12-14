using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
    private Chess _chess { get; set; }
    private BoardCell _cell { get; set; }

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
        _icon.sprite = LevelController.Ins.LevelDatabase.GetSpriteByChess(_chess);

        Debug.LogError($"ChessName: {_chess.ToString()} - {_cell.Coordinates} - {_icon.sprite.name}");

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