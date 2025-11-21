using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;  // assign Pause Menu panel
    public GameObject mainMenuUI;   // assign Main Menu panel
    private bool isPaused = false;

    void Awake()
    {
        // Pause menu is hidden at start
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        isPaused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Toggle pause menu only during gameplay
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;

        // Deselect buttons to fix highlight issues
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        // Deselect buttons
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
    }
    public void QuitToMainMenu()
    {
        // Hide pause menu
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        // Show main menu
        if (mainMenuUI != null)
            mainMenuUI.SetActive(true);

        // Resume time and reset pause state
        Time.timeScale = 1f;
        isPaused = false;

        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
    }
}