using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{

    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;

    public delegate void ViewInventoryUpdateEventHandler(List<Item> characterItems);
    public static event ViewInventoryUpdateEventHandler OnInventoryInfoChange;


    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        InventoryUpdate();
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public void AddItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        InventoryUpdate();
        Debug.Log("Added item: " + itemToAdd.title);

    }

    public Item CheckForItem(int id)
    {
        if (id >= characterItems.Count)
        {
            throw new IndexOutOfRangeException("Numero de items ");
        }
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {

        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            InventoryUpdate();
            Debug.Log("Removed item: " + itemToRemove.title);
        }
    }

    public void InventoryUpdate()
    {
        if (OnInventoryInfoChange != null)
            OnInventoryInfoChange(characterItems);
    }
}
