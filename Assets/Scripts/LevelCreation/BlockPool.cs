using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    public Block blockPrefab;  // Reference to the Player prefab
    private Queue<Block> pool = new Queue<Block>();  // The pool for Player objects
    public int poolSize = 1;

    // Initialize the pool with inactive objects
    void Start()
    {
        // nothing
    }

    // Get a player object from the pool
    public Block GetObject()
    {
        if (pool.Count > 0)
        {
            Block block = pool.Dequeue();
            block.gameObject.SetActive(true);
            return block;
        }
        else
        {
            Block block = Instantiate(blockPrefab);
            block.gameObject.SetActive(true);
            return block;
        }
    }

    // Return a player object to the pool
    public void ReturnObject(Block block)
    {
        block.gameObject.SetActive(false);
        pool.Enqueue(block);
    }
}
