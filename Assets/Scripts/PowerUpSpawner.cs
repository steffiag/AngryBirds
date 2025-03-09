using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject speedPowerUpPrefab;
    public GameObject heavyPowerUpPrefab;
    public Transform[] spawnPoints; 

    private GameObject spawnedPowerUp;

    void Start()
    {
        SpawnRandomPowerUp();
    }

    void SpawnRandomPowerUp()
    {
        if (spawnPoints.Length == 0)
        {
            return;
        }

        Transform spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject selectedPowerUp;
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            selectedPowerUp = speedPowerUpPrefab;
        }
        else 
        {
            selectedPowerUp = heavyPowerUpPrefab;
        }

        spawnedPowerUp = Instantiate(selectedPowerUp, spawnLocation.position, Quaternion.identity); //im pretty sure quaternion identity makes the rotation 0, might change
    }
    
}