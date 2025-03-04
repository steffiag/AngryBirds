using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public PlayerPool playerPool;

    public void SpawnPlayer(Vector3 spawnPosition)
    {
        Player player = playerPool.GetObject();
        player.transform.position = spawnPosition;  // Start Position
    }
}

