using UnityEngine;

public enum Chess
{
    BlackKing, //Vua
    WhiteKing,
    BlackQueen, //Hau
    WhiteQueen,
    BlackBishop, //Tuong
    WhiteBishop,
    BlackKnight, //Ma
    WhiteKnight,
    BlackRook, //Xe
    WhiteRook,
    None
}

[System.Serializable]
public class PieceState
{
    [SerializeField] private Chess _chess;
    public Chess Chess => _chess;

    [SerializeField] private Sprite _sprite;
    public Sprite PieceSprite => _sprite;
}