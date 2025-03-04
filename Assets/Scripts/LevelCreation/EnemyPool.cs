using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public Enemy enemyPrefab;  // Reference to the Player prefab
    private Queue<Enemy> pool = new Queue<Enemy>();  // The pool for Player objects
    public int poolSize = 1;

    // Initialize the pool with inactive objects
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Enemy newEnemy = Instantiate(enemyPrefab);
            newEnemy.gameObject.SetActive(true);
            pool.Enqueue(newEnemy);
        }
    }

    // Get a player object from the pool
    public Enemy GetObject()
    {
        if (pool.Count > 0)
        {
            Enemy enemy = pool.Dequeue();
            enemy.gameObject.SetActive(true);
            return enemy;
        }
        else
        {
            Enemy enemy = Instantiate(enemyPrefab);
            enemy.gameObject.SetActive(true);
            return enemy;
        }
    }

    // Return a player object to the pool
    public void ReturnObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
    }
}
