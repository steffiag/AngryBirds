using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class GameEvents
{
    public static event Action<int> OnScoreUpdated; 

    public static void ScoreUpdated(int points)
    {
        if (OnScoreUpdated != null)
        {
            OnScoreUpdated(points);
        }
    }

    public static event Action OnShotFired;

    public static void ShotFired()
    {
        if (OnShotFired != null)
        {
            OnShotFired();
        }
    }

    public static event Action OnEnemyDied;

    public static void EnemyDied()
    {
        if (OnEnemyDied != null)
        {
            Debug.Log("Nope, this works");
            OnEnemyDied();
        }
    }
}


