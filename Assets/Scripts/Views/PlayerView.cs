using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    private Text playerText;
    private void Awake()
    {
        playerText = GetComponent<Text>();
        Player.OnPlayerInfoChange += updateView;
    }

    private void updateView(object source, EventArgs args)
    {
        //cast de object para player para conseguir ler os atributos.
        Player player = (Player)source;
        playerText.text = "Vida: \t" + player.life.ToString() + "\n" + "Ataque: \t" + player.attackPower.ToString();
    }
}
