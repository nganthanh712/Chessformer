using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class BoardCell : MonoBehaviour
{
    public Vector2Int Coordinates;
    public Pieces Piece;
    [FormerlySerializedAs("obstacle")] public Obstacle Obstacle;
    
    public bool IsOccupied => Piece != null;
}
