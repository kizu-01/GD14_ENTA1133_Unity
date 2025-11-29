using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int HP = 100;
    public int treasuresCollected = 0;

    // UI objects in the Canvas
    public Image hpBar; // Image with type=Filled
    public TextMeshProUGUI hpText;

    void Start()
    {
        // Find UI at runtime
        hpBar = GameObject.Find("HPBarFill").GetComponent<Image>();
        hpText = GameObject.Find("HPText (TMP)").GetComponent<TextMeshProUGUI>();
        UpdateHPUI();
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        if (HP < 0) HP = 0;
        UpdateHPUI();

        if (HP == 0) GameUI.Instance.GameOverScreen();
    }

    public void Heal(int amount)
    {
        if (HP >= 100) return; // do not consume heal if full HP

        HP += amount;
        if (HP > 100) HP = 100;
        UpdateHPUI();
    }

    public void CollectTreasure()
    {
        treasuresCollected++;
        if (treasuresCollected >= 5)
            GameUI.Instance.WinScreen();
    }

    void UpdateHPUI()
    {
        if (hpBar != null) hpBar.fillAmount = HP / 100f;
        if (hpText != null) hpText.text = $"HP: {HP}";
    }
}