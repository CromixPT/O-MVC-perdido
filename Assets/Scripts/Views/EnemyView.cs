using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyView : MonoBehaviour
{
    public Text EnemyText;


    public void CombatStart(string enemyHP, string enemyAttack) {
        string txtCombatStart = $"Vida do inimigo: {enemyHP}\nAtaque do inimigo: {enemyAttack}";
        UpdateView(txtCombatStart);
    }
    private void Awake()
    {
        CombatSuccess();
    }

    public void CombatFailed()
    {
        string txtCombatFailed = $"Não importa. A tua história acabou.";
        UpdateView(txtCombatFailed);
    }

    public void CombatSuccess()
    {
        string txtCombatSuccess = $"Por enquano estás seguro.";
        UpdateView(txtCombatSuccess);
    }


    public void UpdateView(string stringToShow)
    {
        EnemyText.text += stringToShow;
   
    }




    private void Update()
    {

    }
}
