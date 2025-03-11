using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;
    private IProjectileState storedPowerUp = null;
    public Image powerUpIcon;
    public Sprite fastIcon;
    public Sprite heavyIcon;

    public event Action OnPowerUpUsed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StorePowerUp(IProjectileState powerUp, Sprite icon)
    {
        storedPowerUp = powerUp;
        powerUpIcon.sprite = icon;
        powerUpIcon.enabled = true;
        powerUpIcon.color = new Color(1, 1, 1, 1);
        Debug.Log("Stored Power-Up: " + powerUp.GetType().Name);
        Debug.Log("Assigned sprite: " + icon.name);
        StatsManager.Instance.PowerUpUsed();
        
    }

    public IProjectileState GetStoredPowerUp()
    {
        return storedPowerUp;
    }

    public void UsePowerUp()
    {
        if (storedPowerUp != null)
        {
        OnPowerUpUsed?.Invoke();

        ClearPowerUp();
        }
    }

    public void ClearPowerUp()
    {
        storedPowerUp = null;
        powerUpIcon.enabled = false;
    }
}
