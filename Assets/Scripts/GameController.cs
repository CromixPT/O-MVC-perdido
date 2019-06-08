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
    public static StoryView storyView;
    private PlayerView playerView;
    private InventoryView inventoryView;
    public static Player player;

    public InputField inputField;
    private CombatController gamec;

    void Awake()
    {
        //Inicialização dos componentes do jogo

        player = GetComponent<Player>();
        storyView = GameObject.Find("StoryText").GetComponent<StoryView>();
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
        //Converter input para lowercase
        userInput = userInput.ToLower();
        //Ativa o evento de mudança de sala para "chamar" o model
        ChangeRoom(userInput);
        //Garante que o input field tá limpo e novamente ativo.
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
