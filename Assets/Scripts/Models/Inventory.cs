using System;
using UnityEngine;

public class Inventory : ScriptableObject
{    

    public delegate void ViewPlayerUpdateEventHandler(object source, EventArgs args);
    public static event ViewPlayerUpdateEventHandler OnInventoryInfoChange;

    private void Awake()
    {
        GameController.onGameStart += InventoryStart;
    }

    private void InventoryStart()
    {
        
        InfoUpdate();
    }

    private void InfoUpdate()
    {
        if (OnInventoryInfoChange != null)
            OnInventoryInfoChange(this, EventArgs.Empty);
    }
}
