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
        blockPositionsLevel1 = new Vector3[8];
        blockPositionsLevel1[0] = new Vector3(11, -2.6f, 0);
        blockPositionsLevel1[1] = new Vector3(11, -1.06f, 0);
        blockPositionsLevel1[2] = new Vector3(9.2f, -2.945f, 0);
        blockPositionsLevel1[3] = new Vector3(12.8f, -2.945f, 0);
        blockPositionsLevel1[4] = new Vector3(9.9f, -1.83f, 0);
        blockPositionsLevel1[5] = new Vector3(12.1f, -1.83f, 0);
        blockPositionsLevel1[6] = new Vector3(11, -0.3f, 0);
        blockPositionsLevel1[7] = new Vector3(11, 0.47f, 0);

        blockRotationsLevel1 = new Vector3[8];
        blockRotationsLevel1[0] = new Vector3(0, 0, 0);
        blockRotationsLevel1[1] = new Vector3(0, 0, 0);
        blockRotationsLevel1[2] = new Vector3(0, 0, 90);
        blockRotationsLevel1[3] = new Vector3(0, 0, 90);
        blockRotationsLevel1[4] = new Vector3(0, 0, 90);
        blockRotationsLevel1[5] = new Vector3(0, 0, 90);
        blockRotationsLevel1[6] = new Vector3(0, 0, 90);
        blockRotationsLevel1[7] = new Vector3(0, 0, 0);
        

        blockScalesLevel1 = new Vector3[8];
        blockScalesLevel1[0] = new Vector3(15, 1.4f, 1);
        blockScalesLevel1[1] = new Vector3(11, 1.4f, 1);
        blockScalesLevel1[2] = new Vector3(1.4f, 1.4f, 1);
        blockScalesLevel1[3] = new Vector3(1.4f, 1.4f, 1);
        blockScalesLevel1[4] = new Vector3(4, 1.4f, 1);
        blockScalesLevel1[5] = new Vector3(4, 1.4f, 1);
        blockScalesLevel1[6] = new Vector3(4, 1.4f, 1);
        blockScalesLevel1[7] = new Vector3(4, 1.4f, 1);

        enemyPositionsLevel1 = new Vector3[2];
        enemyPositionsLevel1[0] = new Vector3(11, -2, 1);
        enemyPositionsLevel1[1] = new Vector3(11, 1.07f, 1);
    }

    public void SetupLevel(Vector3 playerSpawnPosition, Vector3[] blockPositions, Vector3[] blockRotations, Vector3[] blockScales, Vector3[] enemyPositions)
    {
        playerSpawner.SpawnPlayer(playerSpawnPosition);
        blockSpawner.SpawnBlocks(blockPositions, blockRotations, blockScales);
        enemySpawner.SpawnEnemies(enemyPositions);
    }
}

