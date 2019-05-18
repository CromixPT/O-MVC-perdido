using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model
{
    public List<IAtacaAguenta> agente = new List<IAtacaAguenta>();

    public void InstanciaAgente()
    {
        agente.Add(new Player());
        agente.Add(new EnemyModel());
    }

    public List<IAtacaAguenta> GetAllAgents()
    {
        return agente;
    }

}
