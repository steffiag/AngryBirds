using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to UI text
    private int score = 0; // Current score

    private void OnEnable()
    {
        GameEvents.OnScoreUpdated += UpdateScore;
        GameEvents.OnShotFired += ShotFired; 
        GameEvents.OnEnemyDied += EnemyDied;
    }

    private void OnDisable()
    {
        GameEvents.OnScoreUpdated -= UpdateScore;
        GameEvents.OnShotFired -= ShotFired;
        GameEvents.OnEnemyDied -= EnemyDied;
    }

    private void UpdateScore(int points)
    {
        Debug.Log("yoyoo");
        score += points;
        if (score < 0)
        {
            score = 0;
        }
        Debug.Log($"Score Updated: {score}");
        scoreText.text = "Score: " + score;
    }

    private void ShotFired()
    {
        UpdateScore(-10);
    }

    private void EnemyDied()
    {
        UpdateScore(50);
    }
}



