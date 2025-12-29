using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum Chess
{
    None = 0,
    BlackKing, //Vua
    WhiteKing,
    BlackQueen, //Hau
    WhiteQueen,
    BlackBishop, //Tuong
    WhiteBishop,
    BlackKnight, //Ma
    WhiteKnight,
    BlackRook, //Xe
    WhiteRook
}

public enum ChessType
{
    None = 0,
    King, //Vua
    Queen, //Hau
    Bishop, //Tuong
    Knight, //Ma
    Rook //Xe
}

public enum ChessColor
{
    None = 0,
    Black,
    White
}

[System.Serializable]
public class PieceState
{
    [SerializeField] private Chess _chess;
    public Chess Chess => _chess;
    [SerializeField] private ChessType _chessType;
    public ChessType ChessType => _chessType;
    [SerializeField] private Sprite _sprite;
    public Sprite PieceSprite => _sprite;
    [SerializeField] private ChessColor _chessColor;
    public ChessColor ChessColor => _chessColor;

    public PieceState(ChessType type, ChessColor color, Sprite sprite)
    {
        _chessType = type;
        _chessColor = color;
        _sprite = sprite;
    }
}