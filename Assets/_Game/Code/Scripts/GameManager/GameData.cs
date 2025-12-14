using UnityEngine;

public struct GAMEDATAKEY
{
    public const string LEVEL_NUMBER = "LevelNumber";
}

public class GameData
{
    private int _currentLevel = 0;

    public int GetCurrentLevel() => _currentLevel;

    public int GetLevelNumber()
    {
        return PlayerPrefs.GetInt(GAMEDATAKEY.LEVEL_NUMBER, 0);
    }

    private void SetInt(int levelNo)
    {
        PlayerPrefs.SetInt(GAMEDATAKEY.LEVEL_NUMBER, levelNo);
    }
}