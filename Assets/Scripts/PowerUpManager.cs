using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;
    private IProjectileState storedPowerUp = null;
    public Image powerUpIcon;
    public Sprite fastIcon;
    public Sprite heavyIcon;

    void Awake()
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
    }

    public IProjectileState GetStoredPowerUp()
    {
        return storedPowerUp;
    }

    public void ClearPowerUp()
    {
        storedPowerUp = null;
        powerUpIcon.enabled = false;
    }
}
