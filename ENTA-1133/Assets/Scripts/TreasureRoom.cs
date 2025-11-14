using UnityEngine;

public class TreasureRoom : RoomBaseMono
{
    private bool treasureTaken = false;

    public override void OnRoomEntered()
    {
        base.OnRoomEntered();
        if (!treasureTaken)
            Debug.Log("A treasure chest is here!");
        else
            Debug.Log("The treasure chest is empty.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        Debug.Log("Leaving the treasure room.");
    }

    public override void OnRoomSearched()
    {
        base.OnRoomSearched();
        if (!treasureTaken)
        {
            treasureTaken = true;
            Debug.Log("You found the treasure!");
        }
        else
        {
            Debug.Log("The chest is empty. Nothing left.");
        }
    }
}