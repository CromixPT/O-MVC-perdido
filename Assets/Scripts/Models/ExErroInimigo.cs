using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Exceção customizada
public class ExErroInimigo : Exception
{
    public ExErroInimigo(string message) : base(message)
    {
    }
}