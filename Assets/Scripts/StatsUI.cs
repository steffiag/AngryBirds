using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text levelsWonText;
    [SerializeField] private TMP_Text enemiesKilledText;
    [SerializeField] private TMP_Text powerupsUsedText;

    private void Start()
    {
        if (StatsManager.Instance == null)
        {
            Debug.LogError("StatsManager is missing from the scene. Make sure it exists in the Hierarchy.");
            return;
        }

        Debug.Log("StatsManager found. Initializing UI...");

        StatsManager.Instance.OnLevelWon += UpdateLevelsWon;
        StatsManager.Instance.OnEnemyKilled += UpdateEnemiesKilled;
        StatsManager.Instance.OnPowerUpUsed += UpdatePowerupsUsed;

        RefreshStatsUI();
    }

    private void RefreshStatsUI()
    {
        if (levelsWonText != null)
            UpdateLevelsWon(StatsManager.Instance.GetLevelsWon());
        else
            Debug.LogWarning("levelsWonText reference is missing in StatsUI.");

        if (enemiesKilledText != null)
            UpdateEnemiesKilled(StatsManager.Instance.GetEnemiesKilled());
        else
            Debug.LogWarning("enemiesKilledText reference is missing in StatsUI.");

        if (powerupsUsedText != null)
            UpdatePowerupsUsed(StatsManager.Instance.GetPowerupsUsed());
        else
            Debug.LogWarning("powerupsUsedText reference is missing in StatsUI.");
    }

    private void UpdateLevelsWon(int value)
    {
        if (levelsWonText != null)
        {
            levelsWonText.text = $"Levels Won: {value}";
            Debug.Log($"🔹 Updated Levels Won: {value}");
        }
    }

    private void UpdateEnemiesKilled(int value)
    {
        if (enemiesKilledText != null)
        {
            enemiesKilledText.text = $"Enemies Killed: {value}";
            Debug.Log($"🔹 Updated Enemies Killed: {value}");
        }
    }

    private void UpdatePowerupsUsed(int value)
    {
        if (powerupsUsedText != null)
        {
            powerupsUsedText.text = $"Powerups Used: {value}";
            Debug.Log($"🔹 Updated Powerups Used: {value}");
        }
    }

    private void OnDestroy()
    {
        if (StatsManager.Instance != null)
        {
            StatsManager.Instance.OnLevelWon -= UpdateLevelsWon;
            StatsManager.Instance.OnEnemyKilled -= UpdateEnemiesKilled;
            StatsManager.Instance.OnPowerUpUsed -= UpdatePowerupsUsed;
        }
    }
}
