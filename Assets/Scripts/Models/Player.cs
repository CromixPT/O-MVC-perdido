using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life { get; set; }
    public int attackPower { get; set; }

    public delegate void ViewPlayerUpdateEventHandler(int life, int attackPower);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;
    public static event ViewPlayerUpdateEventHandler OnPlayerDead;

    public void PlayerStart()
    {
        life = 100;
        attackPower = 2;
        PlayerInfoUpdate();
    }

    public void PlayerLifeChange(int quantity)
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

    public void PlayerAttackChange(int quantity)
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

    public void PlayerInfoUpdate()
    {
        if (OnPlayerInfoChange != null)
            OnPlayerInfoChange(life, attackPower);
    }

    public void PlayerDead()
    {
        if (OnPlayerDead != null)
            OnPlayerDead(0, 0);
    }
}
