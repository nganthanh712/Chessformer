using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Board Board;
    public Pieces PiecePrefab;
    
    public void CreatePiece(PieceData data)
    {
        Chess chess = data.ChessData;
        Vector2Int position = data.BoardCellPosition;
        
        Pieces piece = Instantiate(PiecePrefab);

        if (data != default)
        {
            Vector3 posCell = Board.GetPosition(position);
            
            piece.SetData(data);
            piece.Spawn(position, posCell);
        }
    }
}