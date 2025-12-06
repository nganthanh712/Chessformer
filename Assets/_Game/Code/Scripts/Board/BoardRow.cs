using System;
using UnityEngine;

public class BoardRow : MonoBehaviour
{
   public BoardCell[] Cells { get; private set; }

   private void Awake()
   {
      Cells = GetComponentsInChildren<BoardCell>();
   }
}
