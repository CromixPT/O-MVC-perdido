using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour, IAtacaAguenta
{

    public delegate void ViewEnemyUpdateEventHandler(int life, int attackPower);
    public static event ViewEnemyUpdateEventHandler OnEnemyInfoChange;

    private int life { get; set; }
    private int attackPower { get; set; }

    public void Enemy()
    {

        life = Random.Range(10, 21);
        attackPower = Random.Range(2, 8);
        Debug.Log("Criei Inimigo com " + life + " de vida e " + attackPower + " de ataque");
        EnemyInfoUpdate();
    }

    public int AttackPower()
    {
        return attackPower;
    }

    public int Life()
    {
        return life;
    }

    public void Damage(int valor)
    {
        life -= valor;
        if (life < 1)
        {
            Debug.Log("Morte do inimigo");
        }
        EnemyInfoUpdate();
    }

    public void EnemyInfoUpdate()
    {
        if (OnEnemyInfoChange != null)
            OnEnemyInfoChange(life, attackPower);
    }

}
