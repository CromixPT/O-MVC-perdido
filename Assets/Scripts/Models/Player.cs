using System;
using UnityEngine;

public class Player : MonoBehaviour, IAtacaAguenta, IMudarSala
{
    private Inventory inventory;


    private int life { get; set; }
    private int attackPower { get; set; }


    [SerializeField]
    private Sala Room;

    public Sala CurrentRoom
    {
        get { return this.Room; }
        set { Room = value; }
    }

    public delegate void ViewPlayerUpdateEventHandler(int life, int attackPower);
    public static event ViewPlayerUpdateEventHandler OnPlayerInfoChange;
    public static event ViewPlayerUpdateEventHandler OnPlayerDead;


    public event EventHandler<string> OnRoomUpdate;

    // inicializa as variaveis e lança event
    public void PlayerStart()
    {
        life = UnityEngine.Random.Range(40, 80);
        attackPower = UnityEngine.Random.Range(2, 8);
        Debug.Log("Criei Jogador com " + life + " de vida e " + attackPower + " de ataque");
        PlayerInfoUpdate();
        ActualRoom();
        inventory = new Inventory();
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
    public void RoomUpdate(string userInput)
    {
        RoomChange(userInput);
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
    public void RoomChange(string userInput)
    {
        if (CurrentRoom.saidas.Length > 0)
        {
            //Para cada saida existente valida se o input contem o id de sala
            for (int i = 0; i < CurrentRoom.saidas.Length; i++)
            {
                if (userInput.Contains(CurrentRoom.saidas[i].id.ToLower()))
                {
                    CurrentRoom = CurrentRoom.saidas[i].salaSeguinte;
                    //Se a sala for a sala com item adiciona item ao inventario
                    if (CurrentRoom.nome == "GuardarEspada")
                    {
                        try
                        {
                            inventory.AddItem("Espada Mágica");
                        }
                        catch (ExItemInexistente)
                        {

                            throw;
                        }
                    }
                    ActualRoom();
                }
            }
        }

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
    public Sala PlayerCurrentRoom()
    {
        return CurrentRoom;
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
            OnRoomUpdate(this, CurrentRoom.descricao);
    }
}
