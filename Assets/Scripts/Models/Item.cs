using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{    
    public string title;
    public string description;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(string title, string description, Dictionary<string, int> stats)
    {
        this.title = title;
        this.description = description;        
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.title = item.title;
        this.description = item.description;        
        this.stats = item.stats;
    }
}
