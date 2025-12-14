using UnityEngine;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
   public Chess Chess { get; set; }
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

   public void SetData(PieceData state)
   {
       if(state == null) return;
       
       Chess = state.ChessData;
       Debug.LogError($"ChessName: {Chess.ToString()}");
      _icon.sprite = LevelController.Ins.LevelDatabase.GetSprite(Chess);
   }

   public void Spawn(Vector2Int cell, Vector3 position)
   {
       if (Cell != null)
       {
           Cell.Piece = null;
       }
       
       Cell.Coordinates  = cell;
       Cell.Piece = this;
       
       transform.position = position;
   }

}
