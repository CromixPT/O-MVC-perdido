using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Player;

public class PlayerView : MonoBehaviour
{
    Text playerText;

    private void Awake()
    {

        playerText = GetComponent<Text>();

        Player.OnPlayerInfoChange += updateView;



    }

    private void updateView(object source, EventArgs args)
    {
        Player player = (Player)source;

        playerText.text = "Vida: \t" + player.life.ToString() + "\n" + "Ataque: \t" + player.attackPower.ToString();
    }
}
