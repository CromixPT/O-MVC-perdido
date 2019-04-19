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
        try
        {
            Item itemToAdd = itemDatabase.GetItem(id);
            characterItems.Add(itemToAdd);
            Debug.Log("Added item: " + itemToAdd.title);
        }
        catch (Exception ex)
        {

            throw new ArgumentException("Nao existe um item com esse id", ex);
        }
    }

    public void AddItem(string itemName)
    {
        try
        {
            Item itemToAdd = itemDatabase.GetItem(itemName);
            characterItems.Add(itemToAdd);
            Debug.Log("Added item: " + itemToAdd.title);
        }
        catch (Exception ex)
        {

            throw new ArgumentException("Nao existe um item com esse nome", ex);
        }
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        try
        {
            Item itemToRemove = CheckForItem(id);
            if (itemToRemove != null)
            {
                characterItems.Remove(itemToRemove);
                Debug.Log("Removed item: " + itemToRemove.title);
            }
        }
        catch (Exception ex)
        {

            throw new ArgumentException("O item que esta a remover não existe", ex);
        }        
    }

    private void InventoryUpdate()
    {
        if (OnInventoryInfoChange != null)
            OnInventoryInfoChange(this, EventArgs.Empty);
    }
}
