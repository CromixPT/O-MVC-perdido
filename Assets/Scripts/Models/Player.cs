using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScriptableObject
{
    public int life { get; set; }
    public int attackPower { get; set; }


    public delegate void ViewPlayerUpdateEventHandler(object source, EventArgs args);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;

    private void Awake()
    {
        GameController.onGameStart += PlayerStart;
    }

    private void PlayerStart()
    {
        life = 100;
        attackPower = 100;
        InfoUpdate();
    }

    private void InfoUpdate()
    {
        if (OnPlayerInfoChange != null)
            OnPlayerInfoChange(this, EventArgs.Empty);
    }
}
