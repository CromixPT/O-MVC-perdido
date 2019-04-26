using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour
{
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


    // Start is called before the first frame update

    void Awake()
    {
        dado1 = GameObject.FindWithTag("Dado1");
        dado1.GetComponent<Renderer>().enabled = false;
        enemy = GetComponent<EnemyModel>();
        onCombatStart += enemy.Enemy;
        onCombatStart += player.PlayerStart;
        onEnemyPower += enemy.AttackPower;
        onPlayerPower += player.PlayerPower;
        onPlayerLife += player.PlayerLife;
        onEnemyLife += enemy.Life;
        onPlayerDamage += player.LifeUpdate;
        onEnemyDamage += enemy.Damage;
        onDiceRoll += dado.rolar;

    }

    void Start()
    {
        CombatStart();
        //luta();         
    }

    protected virtual void CombatStart()
    {
        if (onCombatStart != null)
        {
            onCombatStart();
        }
    }

    public void Text_Changed(string entrada)
    {
        input = entrada.ToLower();
        if (input == "rolar dados")
        {

            luta();
            dado1.GetComponent<Renderer>().enabled = true;
        }

    }

    public void luta()
    {
        //Inicializar combate

        Debug.Log("Iniciei Combate com jogador " + CombatController.jogador);
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
            }
            jogador = 2;
        }

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
            }
            if (valor_ataque_player > valor_ataque_inimigo)
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

                Debug.Log("Valores de vida depois da jogada: Jogador: " + valor_vida_player + " Inimigo: " + valor_vida_inimigo);
            }
            else if (valor_ataque_player < valor_ataque_inimigo)
            {
                Debug.Log("Jogador perde " + (valor_ataque_inimigo - valor_ataque_player));
                if (onEnemyDamage != null)
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

                Debug.Log("Valores de vida depois da jogada: Jogador: " + valor_vida_player + " Inimigo: " + valor_vida_inimigo);
            }
            jogador = 1;
        }
        dado1.GetComponent<Renderer>().enabled = false;

    }
}