using System;
using UnityEngine;
//publisher

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    public event Action<int> OnLevelWon;
    public event Action<int> OnEnemyKilled;
    public event Action<int> OnPowerUpUsed;

    private int levelsWon = 0;
    private int enemiesKilled = 0;
    private int powerupsUsed = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (PowerUpManager.Instance != null)
        {
            PowerUpManager.Instance.OnPowerUpUsed += PowerUpUsed;
        }
    }

    public void LevelWon()
    {
        levelsWon++;
        PlayerPrefs.SetInt("LevelsWon", levelsWon);
        PlayerPrefs.Save();
        OnLevelWon?.Invoke(levelsWon);
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
        PlayerPrefs.Save();
        OnEnemyKilled?.Invoke(enemiesKilled);
    }

    public void PowerUpUsed()
    {
        powerupsUsed++;
        PlayerPrefs.SetInt("PowerupsUsed", powerupsUsed);
        PlayerPrefs.Save();
        OnPowerUpUsed?.Invoke(powerupsUsed);
    }

    private void OnDestroy()
    {
        if (PowerUpManager.Instance != null)
        {
            PowerUpManager.Instance.OnPowerUpUsed -= PowerUpUsed;
        }
    }

    public int GetLevelsWon() => PlayerPrefs.GetInt("LevelsWon", 0);
    public int GetEnemiesKilled() => PlayerPrefs.GetInt("EnemiesKilled", 0);
    public int GetPowerupsUsed() => PlayerPrefs.GetInt("PowerupsUsed", 0);
}
