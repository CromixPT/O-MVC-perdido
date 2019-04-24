using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public delegate void OnCombatStartEventHandler();
    public static event OnCombatStartEventHandler onCombatStart;

    public delegate int OnEnemyPowerEventHandler();
    public static event OnEnemyPowerEventHandler onEnemyPower;

    public delegate int OnDiceRoll();
    public static event OnDiceRoll onDiceRoll;

    public EnemyModel enemy;
    public Dados dado;
    public int valor_dado;
    // Start is called before the first frame update

    void Awake()
    {
        enemy = GetComponent<EnemyModel>();
        onCombatStart += enemy.Enemy;
        onEnemyPower += enemy.AttackPower;
        onDiceRoll += dado.rolar;

    }

    void Start()
    {
        CombatStart();
        luta();
               
    }

    protected virtual void CombatStart()
    {
        if (onCombatStart != null)
        {
            onCombatStart();
        }
    }

    public void luta()
    {

        if(onEnemyPower!=null)
        {
            int valor=onEnemyPower();
            Debug.Log("Valor do poder de ataque " + valor);
            if (onDiceRoll != null)
              {
                 valor_dado=onDiceRoll();
                 Debug.Log("Valor do poder de ataque com o dado" + (valor + valor_dado));
              }
            
            
        }
        
    }
}
