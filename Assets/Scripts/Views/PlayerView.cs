using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    private Text playerText;

    private void Awake()
    {
        playerText = GetComponent<Text>();
        Player.OnPlayerInfoChange += UpdateView;
    }

    public void UpdateView(object source, EventArgs args)
    {
        //cast de object para player para conseguir ler os atributos.
        var player = (Player)source;
        playerText.text = "Vida: \t" + player.life.ToString() + "\n" + "Ataque: \t" + player.attackPower.ToString();
    }
}
