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
    public bool IsBlack => _color != Color.white;

    private Image _image;
    private Color32 _color;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _color =_image.color;
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
            _image.color = Color.red;
        }
        else
        {
            _image.color = _color;
        }
    }

}