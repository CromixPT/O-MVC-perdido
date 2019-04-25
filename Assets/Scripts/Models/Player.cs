using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int life { get; set; }
    private int attackPower { get; set; }
    private Sala currentSala { get; set; }
    public string sala;

    public delegate void ViewPlayerUpdateEventHandler(int life, int attackPower);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;
    public static event ViewPlayerUpdateEventHandler OnPlayerDead;

    public delegate void StoryViewUpdateEventHandler(string sala);
    public static event StoryViewUpdateEventHandler OnRoomUpdate;
    // inicializa as variaveis e lança event
    public void PlayerStart()
    {
        currentSala = GameObject.Find("SalaInicial").GetComponent<Sala>();
        sala = currentSala.nome;
        life = 100;
        attackPower = 2;
        PlayerInfoUpdate();
        ActualRoom();
    }    

    //metodo publico para alteração da vida
    public void LifeUpdate(int quantity)
    {
        PlayerLifeChange(quantity);
    }
    
    // método publico para alteração do poder de ataque
    public void PowerUpdate(int quantity)
    {
        PlayerAttackChange(quantity);
    }

    // metodo publico para alteração de sala
    public void RoomUpdate(Sala sala)
    {
        RoomChange(sala);
    }

    // altera a variavel life e lança event 
    private void PlayerLifeChange(int quantity)
    {
        life += quantity;
        if (life <= 0)
        {
            life = 0;            
            PlayerDead();
        }
        
        else if (life > 100)
        {
            life = 100;
        }
        PlayerInfoUpdate();
    }

    // altera a variavel attackPower e lança event
    private void PlayerAttackChange(int quantity)
    {
        attackPower += quantity;
        if (life <= 2)
        {
            life = 2;            
        }

        else if (life > 12)
        {
            life = 12;
        }
        PlayerInfoUpdate();
    }

    // metodo privado para alteração de sala
    private void RoomChange(Sala room)
    {
        currentSala = room;
        sala = currentSala.nome;
        ActualRoom();
    }

    // retorna vida
    public int PlayerLife()
    {
        return life;
    }

    // retorna poder
    public int PlayerPower()
    {
        return attackPower;
    }

    // retorna sala actual
    public Sala CurrentRoom()
    {
        return currentSala;
    }

    // lança evento com alterações ao player 
    public void PlayerInfoUpdate()
    {
        if (OnPlayerInfoChange != null)
            OnPlayerInfoChange(life, attackPower);
    }

    // lança evento após morte do player
    public void PlayerDead()
    {
        if (OnPlayerDead != null)
            OnPlayerDead(0, 0);
    }

    // lança evento após actualização da sala
    public void ActualRoom()
    {
        if (OnRoomUpdate != null)
            OnRoomUpdate(sala);
    }
}
