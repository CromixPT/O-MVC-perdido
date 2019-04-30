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

    // Verifica a existência de Item na Base de Dados
    public Item GetItem(string itemName)
    {
        if (!items.Exists(item => item.title == itemName))
        {
            throw new ExItemInexistente("Item não encontrado na Base de Dados");
        }
        return items.Find(item => item.title == itemName);                 
    }

    // Constroi Base de Dados
    void BuildDatabase()
    {
        // exemplos, items a definir
        items = new List<Item>() {
            new Item("Poção de vida", " ",
            new Dictionary<string, int> {
                { "Life", 50 },
                { "Power", 2 }
            }),
            new Item("Poção de força", " ",
            new Dictionary<string, int> {
                { "Life", 2 },
                { "Power", 10 }
            }),
            new Item("Silver Pick", "A pick that could kill a vampire.",
            new Dictionary<string, int> {
                { "Power", 5 },
                { "Mining", 20}
            })
        };
    }
}
