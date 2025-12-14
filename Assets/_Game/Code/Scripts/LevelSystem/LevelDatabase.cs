using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class LevelDatabase : ScriptableObject //Save data Chess, LevelCollection
{
    public LevelCollection LevelCollection;
    public PieceState[] Pieces;

    public void Initialize()
    {
       LevelCollection.Initialize();
    }
    
    public Sprite GetSprite(Chess chess)
    {
        return (from t in Pieces where chess != default && t != default && chess == t.Chess select t.PieceSprite).FirstOrDefault();
    }
}
