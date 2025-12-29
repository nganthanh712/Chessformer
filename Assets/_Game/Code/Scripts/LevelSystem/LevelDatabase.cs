using UnityEngine;

[CreateAssetMenu]
public class LevelDatabase : ScriptableObject //Save data Chess, LevelCollection
{
    public LevelCollection LevelCollection;
    public Pieces PiecePrefab;
    public PieceState[] Pieces;
    public ObstaclesState[] Obtacles;

    private int AmountOfLevels => LevelCollection.LevelDatas.Length;

    public void Initialize()
    {
        LevelCollection.Initialize();
    }

    public ChessType GetPieceType(Chess chessType)
    {
        foreach (PieceState p in Pieces)
        {
            if (p.Chess == chessType)
            {
                return p.ChessType;
            }
        }

        return default;
    }
    
    public ChessColor GetPieceColor(Chess chessType)
    {
        foreach (PieceState p in Pieces)
        {
            if (p.Chess == chessType)
            {
                return p.ChessColor;
            }
        }

        return default;
    }

    public Sprite GetSpriteByChess(Chess chessType)
    {
        foreach (PieceState p in Pieces)
        {
            if (p.Chess == chessType)
            {
                return p.PieceSprite;
            }
        }

        return default;
    }

    public Sprite GetSpriteByObstacles(ObstaclesType obs)
    {
        for (int i = 0; i < Obtacles.Length; i++)
        {
            if (Obtacles[i] != default && obs != default && Obtacles[i].Type != ObstaclesType.None &&
                Obtacles[i].Type == obs)
            {
                return Obtacles[i].GetRandomSprite();
            }
        }

        return default;
    }

    private GameObject GetPrefabByObstacles(ObstaclesType obs)
    {
        for (int i = 0; i < Obtacles.Length; i++)
        {
            if (Obtacles[i] != default && obs != default && Obtacles[i].Type != ObstaclesType.None &&
                Obtacles[i].Type == obs)
            {
                return Obtacles[i].ObstaclePrefab;
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

        foreach (var o in levelData.ObstaclesData)
        {
            GameObject prefab = GetPrefabByObstacles(o.ObstaclesType);

            GameObject obs = Instantiate(prefab);
            Obstacle ob = obs.GetComponent<Obstacle>();
            ob.Init(o);
        }
    }

    public bool IsBlack(Chess chessType)
    {
        foreach (PieceState p in Pieces)
        {
            if (p.Chess == chessType)
            {
                return p.ChessColor == ChessColor.Black;
            }
        }

        return false;
    }
}