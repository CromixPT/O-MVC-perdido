using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAtacaAguenta
{
    private int life { get; set; }
    private int attackPower { get; set; }
    public Sala currentSala;

    public delegate void ViewPlayerUpdateEventHandler(int life, int attackPower);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;
    public static event ViewPlayerUpdateEventHandler OnPlayerDead;

    public delegate void StoryViewUpdateEventHandler(string sala);
    public static event StoryViewUpdateEventHandler OnRoomUpdate;

    // inicializa as variaveis e lança event
    public void PlayerStart()
    {
        life = Random.Range(40, 80);
        attackPower = Random.Range(2, 8);
        Debug.Log("Criei Jogador com " + life + " de vida e " + attackPower + " de ataque");
        PlayerInfoUpdate();
        ActualRoom();
    }    

    //Metodo publico para alteração da vida
    public void LifeUpdate(int quantity)
    {
        PlayerLifeChange(quantity);
    }
    
    // Método publico para alteração do poder de ataque
    public void PowerUpdate(int quantity)
    {
        PlayerAttackChange(quantity);
    }

    // Metodo publico para alteração de sala
    public void RoomUpdate(Sala sala)
    {
        RoomChange(sala);
    }

    // Altera a variavel life e lança event 
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

    // Altera a variavel attackPower e lança event
    private void PlayerAttackChange(int quantity)
    {
        attackPower += quantity;
        if (attackPower <= 2)
        {
            attackPower = 2;            
        }

        else if (attackPower > 12)
        {
            attackPower = 12;
        }
        PlayerInfoUpdate();
    }

    // Metodo privado para alteração de sala
    private void RoomChange(Sala room)
    {        
        currentSala = room;
        ActualRoom();
    }

    // Retorna vida
    public int Life()
    {
        return life;
    }

    // Retorna poder
    public int AttackPower()
    {
        return attackPower;
    }

    // retorna sala actual
    public Sala CurrentRoom()
    {
        return currentSala;
    }

    // Lança evento com alterações ao player 
    public void PlayerInfoUpdate()
    {
        if (OnPlayerInfoChange != null)
            OnPlayerInfoChange(life, attackPower);
    }

    // Lança evento após morte do player
    public void PlayerDead()
    {
        if (OnPlayerDead != null)
            OnPlayerDead(0, 0);
    }

    // Lança evento após actualização da sala
    public void ActualRoom()
    {
        if (OnRoomUpdate != null)
            OnRoomUpdate(currentSala.descricao);
    }
}
