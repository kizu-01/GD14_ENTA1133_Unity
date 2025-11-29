using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    [Header("Main UI")]
    public GameObject gameplayUI;
    public TextMeshProUGUI dungeonLog;

    [Header("Combat UI Panels")]
    public GameObject combatPanel;
    public TextMeshProUGUI combatTitle;
    public Button fightButton;
    public Button rollButton;
    public TextMeshProUGUI rollResult;

    [Header("End Screens")]
    public GameObject winPanel;
    public GameObject gameOverPanel;
    public Button winMainMenuButton; // assign in inspector
    public Button gameOverMainMenuButton; // assign in inspector

    private CombatRoom currentCombatRoom = null;
    private bool combatInProgress = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        combatPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        if (rollButton != null) rollButton.interactable = false;

        // Assign main menu buttons
        if (winMainMenuButton != null) winMainMenuButton.onClick.AddListener(QuitToMainMenu);
        if (gameOverMainMenuButton != null) gameOverMainMenuButton.onClick.AddListener(QuitToMainMenu);
    }

    public void ShowDungeonLog(string text)
    {
        if (dungeonLog != null)
        {
            dungeonLog.text = text;
            CancelInvoke(nameof(ClearDungeonLog));
            Invoke(nameof(ClearDungeonLog), 2f);
        }
    }

    void ClearDungeonLog()
    {
        if (dungeonLog != null)
            dungeonLog.text = "";
    }

    #region Combat

    public void StartCombat(CombatRoom room)
    {
        if (combatInProgress) return;

        currentCombatRoom = room;
        combatInProgress = true;

        combatPanel.SetActive(true);
        combatTitle.text = "Enemy Encountered!";
        if (fightButton != null) fightButton.gameObject.SetActive(true);
        if (rollButton != null)
        {
            rollButton.gameObject.SetActive(false);
            rollButton.interactable = true;
        }
        if (rollResult != null) rollResult.text = "";
    }

    public void PressFight()
    {
        if (fightButton != null) fightButton.gameObject.SetActive(false);
        if (rollButton != null) rollButton.gameObject.SetActive(true);
        combatTitle.text = "Let's Roll!";
    }

    public void PressRoll()
    {
        if (currentCombatRoom == null || currentCombatRoom.HasCombatResolved) return;

        int playerRoll = Random.Range(1, 8);
        int enemyRoll = Random.Range(1, 8);
        bool playerWon = playerRoll >= enemyRoll;

        if (rollResult != null)
            rollResult.text = playerWon
                ? $"You WIN! ({playerRoll} vs {enemyRoll})"
                : $"You LOSE! ({playerRoll} vs {enemyRoll})";

        var stats = FindAnyObjectByType<PlayerStats>();
        if (!playerWon && stats != null)
            stats.TakeDamage(20);

        currentCombatRoom.ResolveCombat(playerWon);

        if (rollButton != null) rollButton.interactable = false;

        Invoke(nameof(EndCombat), 2f);
    }

    void EndCombat()
    {
        combatPanel.SetActive(false);
        combatInProgress = false;
        currentCombatRoom = null;
    }

    #endregion

    #region End Screens

    public void GameOverScreen()
    {
        PauseGameForEndScreen();

        if (gameplayUI != null) gameplayUI.SetActive(false);
        if (combatPanel != null) combatPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void WinScreen()
    {
        PauseGameForEndScreen();

        if (gameplayUI != null) gameplayUI.SetActive(false);
        if (combatPanel != null) combatPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(true);
        winPanel.transform.SetAsLastSibling();
    }

    private void PauseGameForEndScreen()
    {
        // pause the game but allow UI interaction
        Time.timeScale = 0f;

        // Optional: ensure Canvas uses Unscaled Time so buttons work
        Canvas canvas = winPanel != null ? winPanel.GetComponent<Canvas>() : null;
        if (canvas != null)
            canvas.worldCamera = Camera.main;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // unpause
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion
}