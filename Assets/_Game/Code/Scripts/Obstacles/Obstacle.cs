using System;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private ObstaclesType _state { get; set; }
    private BoardCell _cell { get; set; }
    private Image _icon { get; set; }

    private void Awake()
    {
        _icon = GetComponent<Image>();
    }

    public void Init(ObstaclesData data)
    {
        SetData(data);
    }

    private void SetData(ObstaclesData data)
    {
        if (data == null) return;

        _state = data.ObstaclesType;
        _cell = GameController.Ins.BoardManager.GetCell(data.BoardCellVector);
        _icon.sprite = LevelController.Ins.LevelDatabase.GetSpriteByObstacles(_state);

        Spawn(data.BoardCellVector);
    }

    private void Spawn(Vector2Int cell)
    {
        if (_cell != null)
        {
            _cell.Obstacle = null;
        }

        _cell.Coordinates = cell;
        _cell.Obstacle = this;

        transform.SetParent(_cell.transform);
        transform.position = GameController.Ins.BoardManager.GetPositionOfCell(cell);
    }
}