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

    public void UpdateView(int life, int attackPower)
    {
        playerText.text = "Vida: \t" + life.ToString() + "\n" + "Ataque: \t" + attackPower.ToString();
    }
}
