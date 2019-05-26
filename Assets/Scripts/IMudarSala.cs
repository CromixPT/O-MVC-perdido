using System;

public interface IMudarSala
{
    Sala CurrentRoom { get; set; }

    void RoomChange(string userInput);


    event EventHandler<string> OnRoomUpdate;
}
