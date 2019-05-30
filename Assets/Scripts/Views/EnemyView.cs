using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    public Text EnemyText;

    private void Awake()
    {
        EnemyText = GameObject.Find("EnemyText").GetComponent<Text>();
    }

    // Dar output da vida e do poder de ataque
    public void UpdateView(int life, int attackPower)
    {
        EnemyText.text = "Vida: \t" + life.ToString() + "\n" + "Ataque: \t" + attackPower.ToString();
    }
}
