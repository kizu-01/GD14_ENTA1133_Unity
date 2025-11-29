using UnityEngine;

public class HealRoom : RoomBaseMono, IRoomAction
{
    private bool potionTaken = false;

    public override void OnRoomEntered()
    {
        base.OnRoomEntered();

        if (!potionTaken)
            GameUI.Instance.ShowDungeonLog("This is a healing room. Press SPACE to heal!");
        else
            GameUI.Instance.ShowDungeonLog("This room is empty.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        GameUI.Instance.ShowDungeonLog(""); // clear when leaving
    }

    public void OnSearch()
    {
        if (potionTaken)
        {
            GameUI.Instance.ShowDungeonLog("No potion left here.");
            return;
        }

        var player = FindAnyObjectByType<PlayerStats>();
        if (player == null)
        {
            GameUI.Instance.ShowDungeonLog("No player found.");
            return;
        }

        if (player.HP >= 100)
        {
            GameUI.Instance.ShowDungeonLog("Your HP is full. Potion not used.");
            return;
        }

        potionTaken = true;
        player.Heal(20);
        GameUI.Instance.ShowDungeonLog("+20 HP healed!");
    }
}