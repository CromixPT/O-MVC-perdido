using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void GameStartEventHandler();
    public static event GameStartEventHandler onGameStart;

    //public delegate void ViewPlayerUpdateEventHandler(object source, EventArgs args);
    //public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;


    public Sala currentRoom;
    private StoryView storyView;
    private PlayerView playerView;

    private Player player;

    

    // Start is called before the first frame update
    void Awake()
    {

        player = GetComponent<Player>();
        storyView = GetComponent<StoryView>();

    }

    private void Start()
    {
        GameStart();
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
