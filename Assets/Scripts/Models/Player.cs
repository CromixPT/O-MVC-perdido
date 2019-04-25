using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life { get; set; }
    public int attackPower { get; set; }

    public delegate void ViewPlayerUpdateEventHandler(int life, int attackPower);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;
    public static event ViewPlayerUpdateEventHandler OnPlayerDead;

    // inicializa as variaveis e lança event
    public void PlayerStart()
    {
        life = 100;
        attackPower = 2;
        PlayerInfoUpdate();
    }

    //metodo publico para alteração da vida
    public void LifeUpdate(int quantity)
    {
        PlayerLifeChange(quantity);
    }
    
    // método publico para alteração do poder de ataque
    public void PowerUpdate(int quantity)
    {
        PlayerAttackChange(quantity);
    }

    // altera a variavel life e lança event 
    private void PlayerLifeChange(int quantity)
    {
        life += quantity;
        if (life <= 0)
        {
            life = 0;            
            PlayerDead();
        }
        
        else if (life > 100)
        {
            life = 100;
        }
        PlayerInfoUpdate();
    }

    // altera a variavel attackPower e lança event
    private void PlayerAttackChange(int quantity)
    {
        attackPower += quantity;
        if (life <= 2)
        {
            life = 2;            
        }

        else if (life > 12)
        {
            life = 12;
        }
        PlayerInfoUpdate();
    }

    // retorna vida
    public int PlayerLife()
    {
        return life;
    }

    // retorna poder
    public int PlayerPower()
    {
        return attackPower;
    }

    // lança evento com alterações ao player 
    public void PlayerInfoUpdate()
    {
        if (OnPlayerInfoChange != null)
            OnPlayerInfoChange(life, attackPower);
    }

    // lança evento após morte do player
    public void PlayerDead()
    {
        if (OnPlayerDead != null)
            OnPlayerDead(0, 0);
    }
}
