using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType {Speed, Heavy}
    public PowerUpType type;
    public Sprite powerUpIcon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (type == PowerUpType.Speed)
            {
                PowerUpManager.Instance.StorePowerUp(new FastState(), powerUpIcon);
            }
            else if (type == PowerUpType.Heavy)
            {
                PowerUpManager.Instance.StorePowerUp(new HeavyState(), powerUpIcon);
            }
            Destroy(gameObject);
        }
    }
}
