using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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

public enum ChessColor
{
    Black,
    White
}

[System.Serializable]
public class PieceState
{
    [SerializeField] private ChessColor _chessColor;
    public ChessColor ChessColor => _chessColor;
    public PieceTypeData[] PieceTypeData;

    private Dictionary<Chess, Sprite> ChessData = new();

    public Chess GetChessByType(Chess type)
    {
        foreach (var p in PieceTypeData)
        {
            if (type != default && p.Chess != default && p.Chess == type)
            {
                return p.Chess;
            }
        }

        return default;
    }

    public Sprite GetSpriteByType(Chess type)
    {
        foreach (var p in PieceTypeData)
        {
            if (type == default || p.Chess == default) continue;

            if (p.Chess == type)
            {
                return p.PieceSprite;
            }
        }

        return default;
    }
}

[System.Serializable]
public class PieceTypeData
{
    [SerializeField] private Chess _chess;
    public Chess Chess => _chess;
    [SerializeField] private Sprite _sprite;
    public Sprite PieceSprite => _sprite;
}