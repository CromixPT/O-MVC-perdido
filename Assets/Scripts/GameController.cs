using System;
using UnityEngine;
using UnityEngine.UI;

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

    public InputField inputField;

    // Start is called before the first frame update
    void Awake()
    {

        player = GetComponent<Player>();
        storyView = GetComponent<StoryView>();

        inputField.onEndEdit.AddListener(AcceptStringInput);

    }
    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        for (int i = 0; i < currentRoom.saidas.Length; i++)
        {
            if (currentRoom.saidas[i].nome.ToLower().Contains(userInput))
            {                
                currentRoom = currentRoom.saidas[i];
                Debug.Log("Current room: " + currentRoom);
                storyView.ChangeRoom(currentRoom.descricao);
            }
        }

        inputField.ActivateInputField();
        inputField.text = null;
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
