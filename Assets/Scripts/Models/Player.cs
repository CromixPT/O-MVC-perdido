using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life { get; set; }
    public int attackPower { get; set; }

    public delegate void ViewPlayerUpdateEventHandler(object source, EventArgs args);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;
    public static event ViewPlayerUpdateEventHandler OnPlayerDead;

    public void PlayerStart()
    {
        life = 100;
        attackPower = 100;
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

    public void PlayerInfoUpdate()
    {
        if (OnPlayerInfoChange != null)
            OnPlayerInfoChange(this, EventArgs.Empty);
    }

    public void PlayerDead()
    {
        if (OnPlayerDead != null)
            OnPlayerDead(this, EventArgs.Empty);
    }
}
