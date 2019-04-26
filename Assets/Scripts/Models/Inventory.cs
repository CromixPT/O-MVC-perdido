using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{

    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase = ScriptableObject.CreateInstance<ItemDatabase>();

    public delegate void ViewInventoryUpdateEventHandler(List<Item> characterItems);
    public static event ViewInventoryUpdateEventHandler OnInventoryInfoChange;

    public void AddItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        InventoryUpdate();
        Debug.Log("Added item: " + itemToAdd.title);

    }

    public Item CheckForItem(string itemName)
    {        
        return characterItems.Find(item => item.title == itemName);
    }

    public void RemoveItem(string itemName)
    {

        Item itemToRemove = CheckForItem(itemName);
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
