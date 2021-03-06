﻿using System.Collections;
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
        if(life<10||life>20||attackPower<2||attackPower>7)
        {
            throw new ExErroInimigo("Erro Criação Inimigo");
        }
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
            life = 0;
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
