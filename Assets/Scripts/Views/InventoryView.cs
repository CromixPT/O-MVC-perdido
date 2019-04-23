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

    private void UpdateView(object source, EventArgs args)
    {
        //cast de object de inventory para conseguir ler a lista de items.
        var inventory = (Inventory)source;
        inventoryText.text = ListaItems(inventory);
    }

    private string ListaItems(Inventory inventory)
    {
        List<Item> aux = inventory.characterItems;
        string lista = "";
        foreach (var item in aux)
        {
            lista += "- " + item.title + "\n";
        }
        return lista;
    }
}
