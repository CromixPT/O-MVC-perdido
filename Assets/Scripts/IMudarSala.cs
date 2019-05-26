using System;

public interface IMudarSala
{
    Sala CurrentRoom { get; set; }
    void RoomChange(string userInput);
    //Evento que notifica a view para alterar informação
    event EventHandler<string> OnRoomUpdate;
}
