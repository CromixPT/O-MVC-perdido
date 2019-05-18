using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Exceção customizada
public class ExItemInexistente : Exception
{
    public ExItemInexistente(string message) : base(message)
    {
    }
}
