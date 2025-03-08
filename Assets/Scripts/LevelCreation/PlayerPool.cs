using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : MonoBehaviour
{
    public Player playerPrefab;  // Reference to the Player prefab
    private Queue<Player> pool = new Queue<Player>();  // The pool for Player objects
    public int poolSize = 1;

    // Initialize the pool with inactive objects
    void Start()
    {
        // nothing
    }

    // Get a player object from the pool
    public Player GetObject()
    {
        if (pool.Count > 0)
        {
            Player player = pool.Dequeue();
            player.gameObject.SetActive(true);
            return player;
        }
        else
        {
            Player player = Instantiate(playerPrefab);
            player.gameObject.SetActive(true);
            return player;
        }
    }

    // Return a player object to the pool
    public void ReturnObject(Player player)
    {
        player.gameObject.SetActive(false);
        pool.Enqueue(player);
    }
}
