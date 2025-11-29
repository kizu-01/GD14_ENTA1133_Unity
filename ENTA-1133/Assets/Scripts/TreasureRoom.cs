using UnityEngine;

public class TreasureRoom : RoomBaseMono, IRoomAction
{
    private bool taken = false;

    public override void OnRoomEntered()
    {
        base.OnRoomEntered();
        if (!taken)
            GameUI.Instance.ShowDungeonLog("You see a treasure here!");
        else
            GameUI.Instance.ShowDungeonLog("Treasure already taken.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        GameUI.Instance.ShowDungeonLog("");
    }

    public void OnSearch()
    {
        if (!taken)
        {
            taken = true;
            var player = FindAnyObjectByType<PlayerStats>();
            if (player != null)
            {
                player.CollectTreasure();
                GameUI.Instance.ShowDungeonLog("Treasure Found!");
            }
            else
            {
                GameUI.Instance.ShowDungeonLog("Player not found.");
            }
        }
        else
        {
            GameUI.Instance.ShowDungeonLog("Treasure Already Taken.");
        }
    }
}