using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dados : MonoBehaviour
{
    private Sprite[] lados;
    private SpriteRenderer mostrar;
    private bool pode_jogar = true;
    public static int valor;
    public GameObject dado1;

    // Start is called before the first frame update
    /*void Awake()
    {
        dado1 = GameObject.FindWithTag("Dado1");
        dado1.GetComponent<Renderer>().enabled = false;
    }*/

    void Start()
    {
        mostrar = GetComponent<SpriteRenderer>();
        lados = Resources.LoadAll<Sprite>("Dados/");
        mostrar.sprite = lados[0];
        jogar();
    }

    public int rolar()
    {
        Start();
        Dados.valor = Random.Range(0, 6);
        return Dados.valor;

    }


    private void jogar()
    {
        if (pode_jogar == true)
        {
            StartCoroutine("lancar_dados");
        }
    }


    private IEnumerator lancar_dados()
    {

        pode_jogar = false;
        int valor = 0;
        for (int i = 0; i < 15; i++)
        {
            valor = Random.Range(0, 6);
            mostrar.sprite = lados[valor];
            yield return new WaitForSeconds(0.05f);
        }
        mostrar.sprite = lados[Dados.valor];
        pode_jogar = true;
    }

}

