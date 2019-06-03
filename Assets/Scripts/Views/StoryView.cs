using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LogString : MonoBehaviour
{
    public Text DisplayText;


    public void CombatStart(string enemyHP, string enemyAttack)
    {
        string txtCombatStart = $"! COMBATE ! \n Um inimigo com {enemyHP} de vida e {enemyAttack} de ataque apareceu. Prepara-te para lutar.";
        LogString(txtCombatStart);
    }

    public void CombatPlayerPotion(string HPGain)
    {
        string txtCombatPlayerPotion = $"Conseguiste usar uma poção, recuperaste {HPGain} de vida.";
        LogString(txtCombatPlayerPotion);
    }

    public void CombatEnemyAttack(string dmgReceived)
    {
        string txtCombatEnemyAttack = $"O inimigo atacou-te e sofreste {dmgReceived} dano.";
        LogString(txtCombatEnemyAttack);
    }

    public void CombatFailed()
    {
        string txtCombatFailed = $"O ataque do inimigo foi fatal e a tua história acaba aqui.";
        LogString(txtCombatFailed);
    }

    public void CombatSuccess()
    {
        string txtCombatSuccess = $"O inimigo não aguentou o teu ataque. Podes continuar a procura do MVC.";
        LogString(txtCombatSuccess);
    }

    public void CombatPlayerAttack(string dmgInflicted)
    {
        string txtCombatPlayerAttack = $"Atacaste o inimigo e causaste {dmgInflicted} dano.";
        LogString(txtCombatPlayerAttack);

    }

    public void ChangeRoom(string txtChangeRoom)
    {
        LogString(txtChangeRoom + "\n");

    }

    public void LogString(string stringToAdd)
    {
        //If textbox is empty initializes it, elses adds log
        if (DisplayText.text == "")
        {
            DisplayText.text = stringToAdd + "\n";
        }
        else
        {
            DisplayText.text += stringToAdd + "\n";
        }
    }
    

    

    private void Update()
    {

    }
}
