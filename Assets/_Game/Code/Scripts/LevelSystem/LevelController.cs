using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Ins;
    public LevelDatabase LevelDatabase;
    
    private LevelData _levelData;
    public LevelData LevelData => _levelData;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(Ins.gameObject);
        }
        
        Ins = this;

        Init();
    }

    private void Init()
    {
        LevelDatabase.Initialize();
    }
    
    public void LoadLevel(int levelIndex)
    {
        _levelData = LevelDatabase.GetLevelData(levelIndex);
        LevelDatabase.SpawnObject(_levelData);
    }
}