using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject //save data of each level
{
    public PieceData[] PieceData;
    public ObstaclesData[] ObstaclesData;
}

