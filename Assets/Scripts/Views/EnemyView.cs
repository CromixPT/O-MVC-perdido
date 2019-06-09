using UnityEngine;
using UnityEngine.UI;



public class EnemyView : MonoBehaviour
{
    public Text EnemyText;
    public void CombatStart(int enemyHP, int enemyAttack)
    {
        string txtCombatStart = $"Vida do inimigo: {enemyHP.ToString()} \n " +
            $"Ataque do inimigo: {enemyAttack.ToString()}";
        UpdateView(txtCombatStart);
    }
    private void Awake()
    {
        EnemyText = GameObject.Find("EnemyText").GetComponent<Text>();
        CombatSuccess();
    }

    public void CombatFailed()
    {
        string txtCombatFailed = $"Não importa. A tua história acabou.";
        UpdateView(txtCombatFailed);
    }

    public void CombatSuccess()
    {
        string txtCombatSuccess = $"Por enquanto estás seguro.";
        UpdateView(txtCombatSuccess);
    }

    public void UpdateView(string stringToShow)
    {
        EnemyText.text = stringToShow;
    }
}
