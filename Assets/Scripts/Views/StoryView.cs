using UnityEngine;
using UnityEngine.UI;



public class StoryView : MonoBehaviour
{
    public Text DisplayText;
    public void CombatStart(string enemyHP, string enemyAttack)
    {
        string txtCombatStart = $"! COMBATE ! \n Um inimigo com {enemyHP} de vida e {enemyAttack} " +
            $"de ataque apareceu. Prepara-te para <b>lutar.</b";
        UpdateView(txtCombatStart);
    }

    public void CombatPlayerPotion(string HPGain)
    {
        string txtCombatPlayerPotion = $"Conseguiste usar uma poção, recuperaste {HPGain} de vida.";
        UpdateView(txtCombatPlayerPotion);
    }
    public void CombatEnemyAttack(string dmgReceived)
    {
        string txtCombatEnemyAttack = $"O inimigo atacou-te e sofreste {dmgReceived} dano." +
            $" Continua a <b>lutar</b>";
        UpdateView(txtCombatEnemyAttack);
    }

    public void CombatForce(string player, string power)
    {
        string txtCombatForce = $"O {player} tem um poder de ataque de {power} unidades!. " +
            $"Continua a <b>lutar</b>";
        UpdateView(txtCombatForce);
    }

    public void CombatFailed()
    {
        string txtCombatFailed = $"O ataque do inimigo foi fatal e a tua história acaba aqui.";
        UpdateView(txtCombatFailed);
    }

    public void CombatSuccess()
    {
        string txtCombatSuccess = $"O inimigo não aguentou o teu ataque. " +
            $"Podes continuar a procura do MVC.";
        UpdateView(txtCombatSuccess);
    }
    public void CombatPlayerAttack(string dmgInflicted)
    {
        string txtCombatPlayerAttack = $"Atacaste o inimigo e causaste {dmgInflicted} dano. " +
            $"Continua a <b>lutar</b>";
        UpdateView(txtCombatPlayerAttack);

    }
    public void ChangeRoom(object sender, string e)
    {
        UpdateView(e + "\n");

    }
    public void UpdateView(string stringToAdd)
    {
        DisplayText.text = stringToAdd + "\n";
    }
}
