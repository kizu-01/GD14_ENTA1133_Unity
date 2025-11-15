using UnityEngine;

public class EmptyRoom : RoomBaseMono
{
    public override void OnRoomEntered()
    {
        base.OnRoomEntered();
        Debug.Log("This is an empty room.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        Debug.Log("Leaving an empty room.");
    }

    public override void OnRoomSearched()
    {
        base.OnRoomSearched();
        Debug.Log("The room is empty. Nothing found.");
    }
}