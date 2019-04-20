using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDatabase : ScriptableObject
{
    public List<Item> items = new List<Item>();
    public List<Item> result = new List<Item>();

    void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        if (id < 0 || id >= items.Count)
        {
            throw new ArgumentOutOfRangeException("int < 0 || int >= items.Count");
        }
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        if (!items.Exists(item => item.title == itemName))
        {
            throw new ArgumentNullException("string nao encontrada");
        }
        return items.Find(item => item.title == itemName);                 
    }

    void BuildDatabase()
    {
        // exemplos, items a definir
        items = new List<Item>() {
            new Item(0, "Diamond Sword", "A sword made of diamond.",
            new Dictionary<string, int> {
                { "Power", 15 },
                { "Defence", 10 }
            }),
            new Item(1, "Diamond Ore", "A pretty diamond.",
            new Dictionary<string, int> {
                { "Value", 300 }
            }),
            new Item(2, "Silver Pick", "A pick that could kill a vampire.",
            new Dictionary<string, int> {
                { "Power", 5 },
                { "Mining", 20}
            })
        };
    }
}
