using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class LevelCollection : ScriptableObject //Save data all level of game
{
    [SerializeField] private LevelData[] _levelDatas;
    
    public LevelData[] LevelDatas => _levelDatas;
    
    private int _index;

    private int GetLength()
    {
        return _levelDatas.Length;
    }

    public void Initialize()
    {
        for (int i = 0; i < _levelDatas.Length; i++)
        {
            _index = i;
        }
    }


    
  
    
   
}
