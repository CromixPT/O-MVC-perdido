using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Delegates/Eventos do Controller
    public delegate void GameStartEventHandler();
    public static event GameStartEventHandler onGameStart;

    public delegate void RoomChangeEventHandler(string userInput);
    public static event RoomChangeEventHandler onRoomChange;

    //Atributos do Controller
    private LogString storyView;
    private PlayerView playerView;
    private InventoryView inventoryView;
    private Player player;
    private Inventory inventory;
    public InputField inputField;
    private CombatController gamec;

    void Awake()
    {
        //Inicialização dos componentes do jogo
        inventory = new Inventory();
        player = GetComponent<Player>();
        storyView = GameObject.Find("StoryText").GetComponent<LogString>();
        playerView = GameObject.Find("PlayerText").GetComponent<PlayerView>();
        inventoryView = GameObject.Find("InventoryText").GetComponent<InventoryView>();
        gamec = GetComponent<CombatController>();

        //Subscrição de eventos do Player(Model)
        player.OnRoomUpdate += storyView.ChangeRoom;
        Player.OnPlayerInfoChange += playerView.UpdateView;

        //Subscrição de eventos do Controller
        onGameStart += player.PlayerStart;
        onRoomChange += player.RoomUpdate;

        //Subscrição de eventos do inventario
        Inventory.OnInventoryInfoChange += inventoryView.UpdateView;

        //Subscrição de evento de sistema(API) para receber Input
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    private void Start()
    {
        //Inicializa jogo
        GameStart();
        inputField.ActivateInputField();
    }

    protected virtual void GameStart()
    {
        if (onGameStart != null)
        {
            onGameStart();
        }
    }


    void AcceptStringInput(string userInput)
    {

        userInput = userInput.ToLower();
        ChangeRoom(userInput);
        inputField.ActivateInputField();
        inputField.text = null;
    }

    protected void ChangeRoom(string userInput)
    {
        if (onRoomChange != null)
        {
            onRoomChange(userInput);
        }
    }

}
