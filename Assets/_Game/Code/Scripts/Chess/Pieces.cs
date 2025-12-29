using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Pieces : MonoBehaviour, IPointerClickHandler
{
    private Chess _chess { get; set; }
    private ChessType _chessType { get; set; }
    private ChessColor _chessColor { get; set; }
    private BoardCell _cell { get; set; }

    private Image _icon;
    private bool _canSelect = false;

    public bool IsBlack;
    public BoardCell CurrentCell
    {
        get => _cell;
        set => _cell = value;
    }
    
    public ChessType ChessType => _chessType;

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

        _canSelect = true;
        _chess = state.ChessData;

        _chessType = LevelController.Ins.LevelDatabase.GetPieceType(_chess);
        _chessColor = LevelController.Ins.LevelDatabase.GetPieceColor(_chess);
        _cell = GameController.Ins.BoardManager.GetCell(state.BoardCellVector);
        _icon.sprite = LevelController.Ins.LevelDatabase.GetSpriteByChess(_chess);
        IsBlack = LevelController.Ins.LevelDatabase.IsBlack(_chess);

        switch (_chessType)
        {
            case ChessType.King:
                KingPiece kp = gameObject.AddComponent<KingPiece>();
                kp.GetCell(_cell);
                break;
            case ChessType.Queen:
                QueenPiece qp =gameObject.AddComponent<QueenPiece>();
                qp.GetCell(_cell);
                break;
        }

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
        
        transform.SetParent(_cell.Cell.transform);
        transform.position = GameController.Ins.BoardManager.GetPositionOfCell(cell);
    }

    public bool IsEnemy(BoardCell cellFrom)
    {
        if (cellFrom.Piece.IsBlack && IsBlack)
        {
            return false;
        }

        return true;
    }

    public void SetStateCanMove()
    {
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickPiece();
    }

    protected virtual void OnClickPiece()
    {
        
    }
}