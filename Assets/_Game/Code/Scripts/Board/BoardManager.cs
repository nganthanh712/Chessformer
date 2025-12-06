using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Board Board;
    public Pieces PiecePrefab;
    public LevelData LevelData;

    
    
    private void CreateLevel(PieceData data)
    {
        Pieces piece = Instantiate(PiecePrefab);

        if (data != null)
        {
            piece.SetData(data.PieceState);
            piece.Spawn(data.BoardCell);
        }
    }
}