using UnityEngine;
using UnityEngine.UI;



public class StoryView : MonoBehaviour
{
    public Text DisplayText;


    public void CombatStart(string enemyHP, string enemyAttack)
    {
        string txtCombatStart = $"! COMBATE ! \n Um inimigo com {enemyHP} de vida e {enemyAttack} de ataque apareceu. Prepara-te para <b>lutar.</b";
        LogString(txtCombatStart);
    }

    public void CombatPlayerPotion(string HPGain)
    {
        string txtCombatPlayerPotion = $"Conseguiste usar uma poção, recuperaste {HPGain} de vida.";
        LogString(txtCombatPlayerPotion);
    }

    public void CombatEnemyAttack(string dmgReceived)
    {
        string txtCombatEnemyAttack = $"O inimigo atacou-te e sofreste {dmgReceived} dano. Continua a <b>lutar</b>";
        LogString(txtCombatEnemyAttack);
    }

    public void CombatForce(string player, string power)
    {
        string txtCombatForce = $"O {player} tem um poder de ataque de {power} unidades!. Continua a <b>lutar</b>";
        LogString(txtCombatForce);
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
        string txtCombatPlayerAttack = $"Atacaste o inimigo e causaste {dmgInflicted} dano. Continua a <b>lutar</b>";
        LogString(txtCombatPlayerAttack);

    }

    public void ChangeRoom(object sender, string e)
    {
        LogString(e + "\n");

    }

    public void LogString(string stringToAdd)
    {

        //If textbox is empty initializes it, elses adds log
        //if (DisplayText.text == "")
        //{
        //    DisplayText.text = stringToAdd + "\n";
        //}
        //else
        //{
        //    DisplayText.text += stringToAdd + "\n";
        //}

        //To work in a correct way need to have scrolling text area, currently hard to implement in Unity, so replacing all text every room change.
        DisplayText.text = stringToAdd + "\n";
    }




    private void Update()
    {

    }
}
