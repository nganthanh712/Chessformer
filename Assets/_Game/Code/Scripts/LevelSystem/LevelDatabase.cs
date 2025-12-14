using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class LevelDatabase : ScriptableObject //Save data Chess, LevelCollection
{
    public LevelCollection LevelCollection;
    public Pieces PiecePrefab; 
    public PieceState[] Pieces;
    
    private int AmountOfLevels => LevelCollection.LevelDatas.Length;

    public void Initialize()
    {
       LevelCollection.Initialize();
    }
    
    public Sprite GetSprite(Chess chess)
    {
        Debug.LogError($"Chess : {chess.ToString()}");
        foreach (PieceState p in Pieces)
        {
            if (p != default && p.PieceSprite != default && p.Chess == chess)
            {
                return p.PieceSprite;
            }
        }
        
        return default;
    }

    public LevelData GetLevelData(int levelIdx)
    {
        if (levelIdx >= 0 && levelIdx < AmountOfLevels)
        {
            return LevelCollection.LevelDatas[levelIdx];
        }
        
        return null;
    }

    public void SpawnObject(LevelData levelData)
    {
        foreach (var p in levelData.PieceData)
        {
            Pieces go = Instantiate(PiecePrefab);
            go.Init(p);
        }
    }
}
