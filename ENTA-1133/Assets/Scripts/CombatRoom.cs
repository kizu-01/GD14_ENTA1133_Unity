using UnityEngine;

public class CombatRoom : RoomBaseMono
{
    private bool enemyDefeated = false;

    public override void OnRoomEntered()
    {
        base.OnRoomEntered();
        if (!enemyDefeated)
            Debug.Log("Enemies are here! Prepare for combat!");
        else
            Debug.Log("The room is quiet. No enemies remain.");
    }

    public override void OnRoomExited()
    {
        base.OnRoomExited();
        Debug.Log("Leaving the combat room.");
    }

    public override void OnRoomSearched()
    {
        base.OnRoomSearched();
        if (!enemyDefeated)
        {
            enemyDefeated = true;
            Debug.Log("You defeat the enemies!");
        }
        else
        {
            Debug.Log("The room is empty now. All enemies defeated.");
        }
    }
}