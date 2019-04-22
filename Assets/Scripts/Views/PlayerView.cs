using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{

    private void Awake()
    {
    }

    public void updateView(object source, EventArgs args)
    {
        //cast de object para player para conseguir ler os atributos.
        var player = (Player)source;
        
    }
}
