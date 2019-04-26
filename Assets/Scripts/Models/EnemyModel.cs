using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private int life { get; set; }
    private int attackPower { get; set; }

    public void Enemy()
    {

        life = Random.Range(10, 21);
        attackPower = Random.Range(2, 8);
        Debug.Log("Criei Inimigo com " + life + " de vida e " + attackPower + " de ataque");
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
            //Tratar morte jogador
        }
    }

}
