using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
    //Delegates e events do controller
    public delegate void OnCombatStartEventHandler();
    public static event OnCombatStartEventHandler onCombatStart;

    public delegate int OnEnemyPowerEventHandler();
    public static event OnEnemyPowerEventHandler onEnemyPower;

    public delegate int OnPlayerPowerEventHandler();
    public static event OnPlayerPowerEventHandler onPlayerPower;

    public delegate int OnPlayerLifeEventHandler();
    public static event OnPlayerLifeEventHandler onPlayerLife;

    public delegate int OnEnemyLifeEventHandler();
    public static event OnEnemyLifeEventHandler onEnemyLife;

    public delegate void OnPlayerDamageEventHandler(int valor);
    public static event OnPlayerDamageEventHandler onPlayerDamage;

    public delegate void OnEnemyDamageEventHandler(int valor);
    public static event OnEnemyDamageEventHandler onEnemyDamage;

    public delegate int OnDiceRoll();
    public static event OnDiceRoll onDiceRoll;

    public delegate void OnEnemyAppearEventHandler(string vida, string ataque);
    public static event OnEnemyAppearEventHandler onEnemyAppear;

    public delegate void OnEnemyAtackEventHandler(string ataque);
    public static event OnEnemyAtackEventHandler onEnemyAttack;

    public delegate void OnPlayerAtackEventHandler(string ataque);
    public static event OnPlayerAtackEventHandler onPlayerAttack;

    public delegate void OnCombatPowerEventHandler(string player, string ataque);
    public static event OnCombatPowerEventHandler onCombatPower;

    public delegate void OnEnemyDeathEventHandler();
    public static event OnEnemyDeathEventHandler onEnemyDeath;

    public delegate void OnPlayerDeathEventHandler();
    public static event OnPlayerDeathEventHandler onPlayerDeath;

    public delegate void OnEnemyErrorEventHandler();
    public static event OnEnemyErrorEventHandler onEnemyError;


    public delegate void ViewEnemyUpdateEventHandler(int life, int attackPower);

    //Atributos
    public EnemyModel enemy;
    public Dados dado;
    public int valor_dado;
    public Player player;
    public int valor_ataque_player = 0;
    public int valor_vida_inimigo = 0;
    public int valor_vida_player = 0;
    public int valor_ataque_inimigo = 0;
    public GameObject dado1;
    public string input;
    public static int jogador = 1;
    private EnemyView enemyView;
    public StoryView storyView;
    int teste = 0;


    // Start is called before the first frame update

    void Awake()
    {
        dado1 = GameObject.FindWithTag("Dado1");
        dado1.GetComponent<Renderer>().enabled = false;
        enemy = GetComponent<EnemyModel>();
        player = GameController.player;
        storyView = GameController.storyView;
        enemyView = GameObject.Find("EnemyText").GetComponent<EnemyView>();
        enemyView.gameObject.SetActive(false);
        //Subscrição eventos do controller
        onCombatStart += enemy.Enemy;
        onEnemyPower += enemy.AttackPower;
        onPlayerPower += player.AttackPower;
        onPlayerLife += player.Life;
        onEnemyLife += enemy.Life;
        onPlayerDamage += player.LifeUpdate;
        onEnemyDamage += enemy.Damage;
        onDiceRoll += dado.rolar;
        EnemyModel.OnEnemyInfoChange += enemyView.CombatStart;
        onEnemyAppear += storyView.CombatStart;
        onEnemyAttack += storyView.CombatEnemyAttack;
        onPlayerAttack += storyView.CombatPlayerAttack;
        onCombatPower += storyView.CombatForce;
        onEnemyDeath += storyView.CombatSuccess;
        onPlayerDeath += storyView.CombatFailed;
        //onEnemyError += enemyView.CombatSucess;
    }

    void Start()
    {
        try
        {
            CombatStart();
        }
        catch (ExErroInimigo e)
        {
            Debug.Log(e);
        }
        finally
        {
            if(onEnemyError!=null)
            {
                onEnemyError();
            }
        }

        

    }

    protected virtual void CombatStart()
    {
        if (onCombatStart != null)
        {
            onCombatStart();
        }
    }

    //Entrada de texto de teste
    public void Text_Changed(string entrada)
    {
        input = entrada.ToLower();
        if (input == "rolar dados"&&player.CurrentRoom.nome=="Corredor")
        {
            if(teste==0)
            {
                if (onEnemyAppear != null)
                {
                    int vida = onEnemyLife();
                    int ataque = onEnemyPower();
                    onEnemyAppear(vida.ToString(), ataque.ToString());
                }
                teste++;
            }
            luta();
            //Mostrar o dado depois do comando de rolar o dado
            dado1.GetComponent<Renderer>().enabled = true;
        }

    }

    public void luta()
    {
        //Inicializar combate
        Debug.Log("Iniciei Combate com jogador " + CombatController.jogador);
       
        enemyView.gameObject.SetActive(true);
        //Rolar dados para inimigo
        if (CombatController.jogador == 1)
        {
            Debug.Log("Cálculo valores Inimigo");
            if (onEnemyPower != null)
            {
                valor_ataque_inimigo = onEnemyPower();
                if (onDiceRoll != null)
                {
                    valor_dado = onDiceRoll() + 1;
                    valor_ataque_inimigo += valor_dado;
                    Debug.Log("Valor do poder de ataque com o dado" + (valor_ataque_inimigo));
                }
                if(onCombatPower!=null)
                {
                    onCombatPower("Inimigo", valor_ataque_inimigo.ToString());
                }
            }
            jogador = 2;
        }
        //Rolar dados para o jogador
        else if (CombatController.jogador == 2)
        {
            Debug.Log("Cálculo valores jogador");
            if (onPlayerPower != null)
            {
                valor_ataque_player = onPlayerPower();
                if (onDiceRoll != null)
                {
                    valor_dado = onDiceRoll() + 1;
                    valor_ataque_player += valor_dado;
                    Debug.Log("Valor do poder de ataque com o dado" + (valor_ataque_player));
                }
                if (onCombatPower != null)
                {
                    onCombatPower("Jogador", valor_ataque_player.ToString());
                }
            }
            //Atribuição de dano do combate
            if (valor_ataque_player >= valor_ataque_inimigo)
            {
                Debug.Log("Inimigo perde " + (valor_ataque_player - valor_ataque_inimigo));
                if (onEnemyDamage != null)
                {
                    onEnemyDamage(valor_ataque_player - valor_ataque_inimigo);
                }
                if (onPlayerLife != null)
                {
                    valor_vida_player = onPlayerLife();
                }
                if (onEnemyLife != null)
                {
                    valor_vida_inimigo = onEnemyLife();
                }
                if(onPlayerAttack!=null)
                {
                    onPlayerAttack((valor_ataque_player - valor_ataque_inimigo).ToString());
                }

                Debug.Log("Valores de vida depois da jogada: Jogador: " + valor_vida_player + " Inimigo: " + valor_vida_inimigo);
            }
            else if (valor_ataque_player < valor_ataque_inimigo)
            {
                Debug.Log("Jogador perde " + (valor_ataque_inimigo - valor_ataque_player));
                if (onPlayerDamage != null)
                {
                    onPlayerDamage(valor_ataque_player - valor_ataque_inimigo);
                }
                if (onPlayerLife != null)
                {
                    valor_vida_player = onPlayerLife();
                }
                if (onEnemyLife != null)
                {
                    valor_vida_inimigo = onEnemyLife();
                }
                if (onEnemyAttack != null)
                {
                    onEnemyAttack((valor_ataque_inimigo - valor_ataque_player).ToString());
                }

                Debug.Log("Valores de vida depois da jogada: Jogador: " + valor_vida_player + " Inimigo: " + valor_vida_inimigo);
            }
            jogador = 1;
            if(onEnemyLife()<=0)
            {
               if(onEnemyDeath!=null)
                {
                    onEnemyDeath();
                }
                dado1.GetComponent<Renderer>().enabled = false;
                player.RoomChange("vitoria1");
               
            }
            if (onPlayerLife() <= 0)
            {
               if (onPlayerDeath != null)
                {
                    onPlayerDeath();
                }
                dado1.GetComponent<Renderer>().enabled = false;
                player.RoomChange("derrota");

            }
        }
        //Esconder o dado
        dado1.GetComponent<Renderer>().enabled = false;

    }
}