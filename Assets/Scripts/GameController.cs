using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void GameStartEventHandler();
    public static event GameStartEventHandler onGameStart;

    public delegate void ViewPlayerUpdateEventHandler(object source, EventArgs args);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;

    public PlayerView playerView;
    public Sala currentRoom;

    public StoryView storyView;

    [HideInInspector]
    public Player player;

    

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
        storyView = GetComponent<StoryView>();
        //onGameStart += player.PlayerStart;

    }

    private void Start()
    {
        storyView.ChangeRoom(currentRoom.descricao);
    }

    protected virtual void GameStart()
    {
        if (onGameStart != null)
        {
            onGameStart();
        }
    }

}
