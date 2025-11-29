using UnityEngine;

public class EmptyRoom : RoomBaseMono
{
    public override void OnRoomEntered()
    {
        base.OnRoomEntered();
        GameUI.Instance.ShowDungeonLog("Just an empty room.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        GameUI.Instance.ShowDungeonLog("");
    }

    public override void OnRoomSearched()
    {
        base.OnRoomSearched();
        GameUI.Instance.ShowDungeonLog("Nothing to be found.");
    }
}