using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    private Text InventoryText;

    private void Awake()
    {
        InventoryText = GetComponent<Text>();
        Inventory.OnInventoryInfoChange += UpdateView;
    }

    private void UpdateView(List<Item> characterItems)
    {
        InventoryText = GameObject.Find("InventoryText").GetComponent<Text>();
        InventoryText.text = ListaItems(characterItems);
    }

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
