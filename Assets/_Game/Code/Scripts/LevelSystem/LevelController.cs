using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Ins;
    public LevelDatabase LevelDatabase;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(Ins.gameObject);
        }
        
        Ins = this;
    }

    public void Init()
    {
        LevelDatabase.Initialize();
    }
}