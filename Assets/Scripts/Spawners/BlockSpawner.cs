using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public BlockPool blockPool;
    
    public void SpawnBlocks(Vector3[] blockPositions, Vector3[] blockRotations, Vector3[] blockScales)
    {
        for (int i = 0; i < blockPositions.Length; i++)
        {
            Block block = blockPool.GetObject();
            block.transform.position = blockPositions[i];
            block.transform.rotation = Quaternion.Euler(blockRotations[i]);
            block.transform.localScale = blockScales[i];
        }
    }
}

