using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;

    
    public void SpawnEnemies(Vector3[] enemyPositions)
    {
        foreach (var position in enemyPositions)
        {
            Enemy enemy = enemyPool.GetObject(); 
            enemy.transform.position = position; 
            
            // we could probably set a new state here like [ enemy spawned in ] or something
        }
    }
    
}

