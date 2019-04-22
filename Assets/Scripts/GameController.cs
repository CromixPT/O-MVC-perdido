using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void GameStartEventHandler();
    public static event GameStartEventHandler onGameStart;

    public delegate void ViewPlayerUpdateEventHandler(object source, EventArgs args);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;

    public PlayerView playerView;
    public Player player;

    // Start is called before the first frame update
    void Awake()
    {
        
        onGameStart += player.PlayerStart;
        GameStart();
        
        
    }

    protected virtual void GameStart()
    {
        if (onGameStart != null)
        {
            onGameStart();
        }
    }

}
