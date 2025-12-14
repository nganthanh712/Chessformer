using UnityEngine;

public struct GAMEDATAKEY
{
    public const string LEVEL_NUMBER = "LevelNumber";
}

public class GameData
{
    private int _currentLevel = 0;
    public static int CurrentLevel => GetLevelNumber();
    public void SetLevelNumber(int level) => SetLevel(level);

    private static int GetLevelNumber()
    {
        return PlayerPrefs.GetInt(GAMEDATAKEY.LEVEL_NUMBER, 0);
    }

    private static void SetLevel(int levelNo)
    {
        PlayerPrefs.SetInt(GAMEDATAKEY.LEVEL_NUMBER, levelNo);
    }
}