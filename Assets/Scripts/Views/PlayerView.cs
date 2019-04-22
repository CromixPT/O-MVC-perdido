using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    Text playerText = GameObject.Find("Canvas/PlayerText").GetComponent<Text>();
    private void Awake()
    {
    }

    public void updateView(object source, EventArgs args)
    {
        //cast de object para player para conseguir ler os atributos.
        var player = (Player)source;
        playerText.text = "Vida: \t" + player.life.ToString() + "\n" + "Ataque: \t" + player.attackPower.ToString();
    }
}
