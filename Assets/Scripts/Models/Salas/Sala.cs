using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="MVC Perdido/Sala")]
public class Sala : ScriptableObject
{
    public string nome;

    [TextArea(1, 30)]
    public string descricao;

    public Sala[] saidas ;


}
