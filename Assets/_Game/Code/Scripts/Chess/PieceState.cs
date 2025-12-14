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

    public PieceState(Chess chess, Sprite sprite)
    {
        _chess = chess;
        _sprite = sprite;
    }

    public PieceState GetPieceState(Chess chess)
    {
        if (chess != default && chess.Equals(_chess))
        {
            return this;
        }

        return null;
    }
}
