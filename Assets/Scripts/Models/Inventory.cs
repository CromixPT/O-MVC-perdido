﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{

    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase = ScriptableObject.CreateInstance<ItemDatabase>();

    public delegate void ViewInventoryUpdateEventHandler(List<Item> characterItems);
    public static event ViewInventoryUpdateEventHandler OnInventoryInfoChange;

    // Adiciona Item ao inventário (exceção criada na origem itemDatabase.GetItem(itemName))
    public void AddItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        InventoryUpdate();
        Debug.Log("Added item: " + itemToAdd.title);

    }

    // verifica a existência de item no inventário com exceção caso não exista
    public Item CheckForItem(string itemName)
    {
        if (!characterItems.Exists(item => item.title == itemName))
        {
            throw new ArgumentNullException("Item não encontrado no Inventário");
        }
        return characterItems.Find(item => item.title == itemName);
    }

    // remove item no Inventário
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

    // Lança evento a cada actualização do inventário
    public void InventoryUpdate()
    {
        if (OnInventoryInfoChange != null)
            OnInventoryInfoChange(characterItems);
    }
}
