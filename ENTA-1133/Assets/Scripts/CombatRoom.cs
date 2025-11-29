using UnityEngine;

public class CombatRoom : RoomBaseMono
{
    private bool enemyDefeated = false;
    private bool combatResolved = false; // prevents re-rolls (win or lose)

    // expose whether this room's combat was resolved (either win or lose)
    public bool HasCombatResolved => combatResolved;

    public override void OnRoomEntered()
    {
        base.OnRoomEntered();

        if (!enemyDefeated && !combatResolved)
            GameUI.Instance.StartCombat(this); // Pass THIS room
        else
            GameUI.Instance.ShowDungeonLog("Enemies already cleared here.");
    }

    // Called from GameUI after roll
    public void ResolveCombat(bool playerWon)
    {
        if (combatResolved) return; // already handled
        combatResolved = true;      // prevent further rolls
        if (playerWon)
            enemyDefeated = true;
    }

    public override void OnRoomSearched()
    {
        base.OnRoomSearched();
        if (enemyDefeated)
            GameUI.Instance.ShowDungeonLog("You defeated enemies here.");
    }
}