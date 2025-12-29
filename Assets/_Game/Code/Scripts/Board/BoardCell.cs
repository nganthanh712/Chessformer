using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BoardCell : MonoBehaviour
{
    public Vector2Int Coordinates;
    public Pieces Piece;
    public Obstacle Obstacle;
    public Image Cell;
    public Image CellCanMove;
    public Sprite DotImg;
    public bool IsBlack => _color != Color.white;

    private Image _image;
    private Color32 _color;

    private void Awake()
    {
        _color = Cell.color;
    }

    public bool IsOccupied => Piece != null || Obstacle != null;

    public bool IsInsideBoard()
    {
        return Coordinates.x >= 0 && Coordinates.x < GameController.Ins.BoardManager.Board.ColumnCount
                                  && Coordinates.y >= 0 &&
                                  Coordinates.y < GameController.Ins.BoardManager.Board.RowCount;
    }

    public void SetStateCanMove(bool canMove)
    {
        if (canMove)
        {
            CellCanMove.sprite = DotImg;
            SetAlpha(CellCanMove, 0.5f);
        }
        else
        {
            CellCanMove.sprite = default;
            SetAlpha(CellCanMove, 1f);
        }
    }

    private void SetAlpha(Image _image, float alpha)
    {
        var color = _image.color;
        color.a = alpha;
        _image.color = color;
    }

    public void SetColor(Color32 color)
    {
        Cell.color = color;
    }
}