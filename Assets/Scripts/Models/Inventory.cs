using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : ScriptableObject
{

    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;

    public delegate void ViewInventoryUpdateEventHandler(object source, EventArgs args);
    public static event ViewInventoryUpdateEventHandler OnInventoryInfoChange;


    public void AddItem(int id)
    {        
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);          
    }

    public void AddItem(string itemName)
    {       
         Item itemToAdd = itemDatabase.GetItem(itemName);
         characterItems.Add(itemToAdd);
         Debug.Log("Added item: " + itemToAdd.title);
        
    }

    public Item CheckForItem(int id)
    {
        if (id < 0 || id >= characterItems.Count)
        {
            throw new IndexOutOfRangeException("int < 0 || int >= characterItems.Count");
        }
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            Debug.Log("Removed item: " + itemToRemove.title);
        }              
    }

    private void InventoryUpdate()
    {
        if (OnInventoryInfoChange != null)
            OnInventoryInfoChange(this, EventArgs.Empty);
    }
}
