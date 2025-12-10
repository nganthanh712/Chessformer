using System;
using UnityEngine;

[Serializable]
public class BoardCell : MonoBehaviour
{
    public Vector2Int Coordinates;
    public Pieces Piece;
}
