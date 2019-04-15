using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void GameStartEventHandler();
    public static event GameStartEventHandler onGameStart;

    // Start is called before the first frame update

    void Awake()
    {
        Player player = ScriptableObject.CreateInstance<Player>();

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
