using UnityEngine;

public enum ObstaclesType
{
    None,
    Wall
}

[System.Serializable]
public class ObstaclesState
{
    [SerializeField] private ObstaclesType _obstacleType;
    public ObstaclesType Type => _obstacleType;
    [SerializeField] private Sprite[] _obstacleSprite;
    public Sprite[] Sprite => _obstacleSprite;
    [SerializeField] GameObject _obstaclePrefab;
    public GameObject ObstaclePrefab => _obstaclePrefab;

    public Sprite GetRandomSprite()
    {
        return _obstacleSprite[Random.Range(0, _obstacleSprite.Length)];
    }
}