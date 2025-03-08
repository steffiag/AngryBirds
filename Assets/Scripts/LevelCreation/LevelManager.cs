using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour
{
    // Level Data
    public Vector3[] blockPositionsLevel1;
    public Vector3[] blockRotationsLevel1;
    public Vector3[] blockScalesLevel1;

    public Vector3[] enemyPositionsLevel1;

    // I'll add the other arrays after setting up

    public BlockSpawner blockSpawner;
    public EnemySpawner enemySpawner;
    public PlayerSpawner playerSpawner;

    public void Start()
    {
        SetMapValues();
        SetupLevel(Vector3.zero, blockPositionsLevel1, blockRotationsLevel1, blockScalesLevel1, enemyPositionsLevel1);
    }

    public void SetMapValues()
    {
        // Level 1 Data
        blockPositionsLevel1 = new Vector3[3];
        blockPositionsLevel1[0] = new Vector3(8, 0, 0);
        blockPositionsLevel1[1] = new Vector3(3, 0, 0);
        blockPositionsLevel1[2] = new Vector3(4, 0, 0);

        blockRotationsLevel1 = new Vector3[3];
        blockRotationsLevel1[0] = new Vector3(0, 0, 0);
        blockRotationsLevel1[1] = new Vector3(0, 0, 0);
        blockRotationsLevel1[2] = new Vector3(0, 0, 0);
        

        blockScalesLevel1 = new Vector3[3];
        blockScalesLevel1[0] = new Vector3(14, 1.4f, 1);
        blockScalesLevel1[1] = new Vector3(1, 1, 1);
        blockScalesLevel1[2] = new Vector3(1, 1, 1);

        enemyPositionsLevel1 = new Vector3[1];
        enemyPositionsLevel1[0] = new Vector3(1, 1, 1);
    }

    public void SetupLevel(Vector3 playerSpawnPosition, Vector3[] blockPositions, Vector3[] blockRotations, Vector3[] blockScales, Vector3[] enemyPositions)
    {
        playerSpawner.SpawnPlayer(playerSpawnPosition);
        blockSpawner.SpawnBlocks(blockPositions, blockRotations, blockScales);
        enemySpawner.SpawnEnemies(enemyPositions);
    }
}

