using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Board Board;
    public Pieces PiecePrefab;

    
    
    private void CreatePiece(PieceData data)
    {
        Pieces piece = Instantiate(PiecePrefab);

        if (data != null)
        {
            Vector3 posCell = Board.GetPosition(data.BoardCellPosition);
            
            piece.SetData(data.PieceState);
            piece.Spawn(data.BoardCellPosition, posCell);
        }
    }
}