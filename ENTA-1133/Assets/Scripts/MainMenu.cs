using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;        // for Main Menu
    public GameObject gameplayUI;    // for UI Manager
    public GameManager gameManager;  // for GameManager

    public void ButtonStartGame()
    {
        // Hide main menu UI
        if (menuUI != null) menuUI.SetActive(false);

        // Show gameplay UI
        if (gameplayUI != null) gameplayUI.SetActive(true);

        // Reset and start the game
        if (gameManager != null)
            gameManager.ResetGame();
    }

    public void ButtonExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}