using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    private Sprite[] lados;
    private SpriteRenderer mostrar;
    private bool pode_jogar = true;
    // Start is called before the first frame update
    void Start()
    {
        mostrar = GetComponent<SpriteRenderer>();
        lados = Resources.LoadAll<Sprite>("Dados/");
        mostrar.sprite = lados[0];
        GameController.onGameStart += rolar;
        
    }

    private void rolar()
    {
        if (pode_jogar==true)
        {
            StartCoroutine("lancar_dados");
        }
    }

    private IEnumerator lancar_dados()
    {
        pode_jogar = false;
        int valor = 0;
        for(int i=0;i<15;i++)
        {
            valor = Random.Range(0, 6);
            mostrar.sprite = lados[valor];
            yield return new WaitForSeconds(0.05f);
        }
        pode_jogar = true;
    }
 
}
