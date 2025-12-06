using UnityEngine;
using UnityEngine.UI;

public enum PieceType{King, Queen, Rook, Bishop, Knight, Pawn}
public enum PieceColor{Black, White}

public class Pieces : MonoBehaviour
{
   public PieceState PieceState { get; set; }
   public BoardCell Cell { get; set; }
   
   public Vector2Int[] Directions = new[]
   {
     Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left
   };

   private Image _icon;

   private void Awake()
   {
       _icon = GetComponent<Image>();
   }

   public void SetData(PieceState state)
   {
       if(state == null) return;
       
       PieceState = state;
      _icon.sprite = state.PieceSprite;
   }

   public void Spawn(BoardCell cell)
   {
       if (Cell != null)
       {
           Cell.Piece = null;
       }
       
       Cell  = cell;
       Cell.Piece = this;
       
       transform.position = cell.transform.position;
   }

   public virtual void GetLegalMoves(){}
}
