using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Ins;
    
    public BoardManager BoardManager;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        
        Ins = this;
    }

    private void Start()
    {
        PlayGame();
    }

    private void PlayGame()
    {
        int curLevel = GameData.CurrentLevel;
        
        Debug.LogError($"Current level: {curLevel}");
        
        LevelController.Ins.LoadLevel(curLevel);
    }
}
