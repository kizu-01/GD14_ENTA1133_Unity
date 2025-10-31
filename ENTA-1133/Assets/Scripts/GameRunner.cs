using GD14_1133_Lab3_DiceGame_Cadelinia_Demi.Scripts;
using System;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Show welcome message
        Debug.Log("∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘");
        Debug.Log("Welcome to The Dice Game! Made by Demi Cadelinia as of October 23, 2025.");
        Debug.Log("∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘-∘");
        Debug.Log("");

        // Show game instructions

        Debug.Log("How to Play:");
        Debug.Log("1. Each player will automatically choose a die to roll (d4, d6, d8, d12, or d20).");
        Debug.Log("2. Whoever rolls the higher number wins the round and gets a point.");
        Debug.Log("3. If it’s a tie, no one gets a point and the game ends.");
        Debug.Log("");
        Debug.Log("That's it. Let the game begin!");
        Debug.Log("");

        // Create model objects
        Player player = new Player("CPU A");
        Player opponent = new Player("CPU B");
        Die die = new Die();
        System.Random rd = new System.Random();
        Dungeon dungeon = new Dungeon();

        // Possible die choices
        int[] diceOptions = new int[] { 4, 6, 8, 12, 20 };

        // Auto-choose dice for both players (random pick from available options)
        int playerChoice = diceOptions[rd.Next(diceOptions.Length)];
        int opponentChoice = diceOptions[rd.Next(diceOptions.Length)];

        Debug.Log($"{player.Name} auto-chooses d{playerChoice}");
        Debug.Log($"{opponent.Name} auto-chooses d{opponentChoice}");

        // Decide turn order randomly (only affects print order & both will roll once)
        bool playerFirst = rd.Next(2) == 0;
        Debug.Log(playerFirst ? $"{player.Name} will roll first." : $"{opponent.Name} will roll first.");

        // Both roll once according to turn order (compute both rolls, but print order follows turn)
        int playerRoll, opponentRoll;
        if (playerFirst)
        {
            playerRoll = player.RollWithDie(playerChoice, die);
            Debug.Log($"{player.Name} rolled {playerRoll} on a d{playerChoice}.");
            opponentRoll = opponent.RollWithDie(opponentChoice, die);
            Debug.Log($"{opponent.Name} rolled {opponentRoll} on a d{opponentChoice}.");
        }
        else
        {
            opponentRoll = opponent.RollWithDie(opponentChoice, die);
            Debug.Log($"{opponent.Name} rolled {opponentRoll} on a d{opponentChoice}.");
            playerRoll = player.RollWithDie(playerChoice, die);
            Debug.Log($"{player.Name} rolled {playerRoll} on a d{playerChoice}.");
        }

        // Decide winner
        if (playerRoll > opponentRoll)
        {
            Debug.Log($"{player.Name} wins the round!");
            player.Score++;
        }
        else if (opponentRoll > playerRoll)
        {
            Debug.Log($"{opponent.Name} wins the round!");
            opponent.Score++;
        }
        else
        {
            Debug.Log("It's a tie! (no points)");
        }

        Debug.Log($"Final Score this round: {player.Name} = {player.Score} | {opponent.Name} = {opponent.Score}");
        Debug.Log("Goodbye! Thanks for playing :D");
    }
}
