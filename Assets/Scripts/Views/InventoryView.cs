using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    public Text InventoryText;

    private void Awake()
    {
        InventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
    }

    // Dar output dos items que se encontram no inventario do jogador
    public void UpdateView(List<Item> characterItems)
    {
        InventoryText.text = ListaItems(characterItems);
    }

    // Criação da lista de items que estão no inventario do jogador
    private string ListaItems(List<Item> characterItems)
    {
        string lista = "";
        foreach (var item in characterItems)
        {
            lista += "- " + item.title + "\n";
        }
        return lista;
    }
}
