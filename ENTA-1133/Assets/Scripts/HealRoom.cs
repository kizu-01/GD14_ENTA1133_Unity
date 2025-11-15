using UnityEngine;

public class HealRoom : RoomBaseMono
{
    private bool potionTaken = false;
    public override void OnRoomEntered()
    {
        base.OnRoomEntered();
        if (!potionTaken)
            Debug.Log("This is a healing room.");
        else
            Debug.Log("This room is empty.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        Debug.Log("Leaving the healing room.");
    }

    public override void OnRoomSearched()
    {
        base.OnRoomSearched();
        if (!potionTaken)
        {
            potionTaken = true;
            Debug.Log("You found a healing potion!");
        }
        else
        {
            Debug.Log("The room is empty. Nothing left.");
        }
    }
}