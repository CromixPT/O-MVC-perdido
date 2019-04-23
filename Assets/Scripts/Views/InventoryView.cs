using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    private Text inventoryText;

    private void Awake()
    {
        inventoryText = GetComponent<Text>();
        Inventory.OnInventoryInfoChange += UpdateView;
    }

    private void UpdateView(List<Item> characterItems)
    {
        inventoryText.text = ListaItems(characterItems);
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
