using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    
    public Text PlayerText;

    private void Awake()
    {
        PlayerText = GameObject.Find("PlayerText").GetComponent<Text>();
        Player.OnPlayerInfoChange += UpdateView;
    }

    public void UpdateView(int life, int attackPower)
    {
        PlayerText.text = "Vida: \t" + life.ToString() + "\n" + "Ataque: \t" + attackPower.ToString();
    }
}
