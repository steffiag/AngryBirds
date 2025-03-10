using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Level Data
    public Vector3[] blockPositionsLevel1;
    public Vector3[] blockRotationsLevel1;
    public Vector3[] blockScalesLevel1;

    public Vector3[] enemyPositionsLevel1;

    public Vector3[] blockPositionsLevel2;
    public Vector3[] blockRotationsLevel2;
    public Vector3[] blockScalesLevel2;

    public Vector3[] enemyPositionsLevel2;

    public Vector3[] blockPositionsLevel3;
    public Vector3[] blockRotationsLevel3;
    public Vector3[] blockScalesLevel3;

    public Vector3[] enemyPositionsLevel3;
    private Dictionary<int, string> levels = new Dictionary<int, string>();
    private string currentScene;



    // I'll add the other arrays after setting up

    public BlockSpawner blockSpawner;
    public EnemySpawner enemySpawner;
    public PlayerSpawner playerSpawner;

    public void Start()
    {
        levels.Add(1, "Level 1");
        levels.Add(2, "Level 2");
        levels.Add(3, "Level 3");
        SetMapValues();

        int newSceneCount = 0;
        currentScene = SceneManager.GetActiveScene().name;
        for (int i = 1; i<=levels.Count; i++){
            if (levels[i] == currentScene){
                newSceneCount = i + 1;
                break;
            }
        }

        if (newSceneCount == 1)
        {
            SetupLevel(Vector3.zero, blockPositionsLevel1, blockRotationsLevel1, blockScalesLevel1, enemyPositionsLevel1);
        } else if (newSceneCount == 2)
        {
            SetupLevel(Vector3.zero, blockPositionsLevel2, blockRotationsLevel2, blockScalesLevel2, enemyPositionsLevel2);
        } else {
            SetupLevel(Vector3.zero, blockPositionsLevel3, blockRotationsLevel3, blockScalesLevel3, enemyPositionsLevel3);
        }
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

        // Level 2 Data
        blockPositionsLevel2 = new Vector3[9];
        blockPositionsLevel2[0] = new Vector3(9.6f, -3.05f, 0);
        blockPositionsLevel2[1] = new Vector3(9.6f, -1.47f, 0);
        blockPositionsLevel2[2] = new Vector3(8.8f, -2.26f, 0);
        blockPositionsLevel2[3] = new Vector3(8.8f, -0.68f, 0);
        blockPositionsLevel2[4] = new Vector3(10.4f, -0.68f, 0);
        blockPositionsLevel2[5] = new Vector3(10.4f, -2.26f, 0);
        blockPositionsLevel2[6] = new Vector3(9.6f, 0.1f, 0);
        blockPositionsLevel2[7] = new Vector3(7f, -1.52f, 0);
        blockPositionsLevel2[8] = new Vector3(12.2f, -1.52f, 0);

        blockRotationsLevel2 = new Vector3[9];
        blockRotationsLevel2[0] = new Vector3(0, 0, 0);
        blockRotationsLevel2[1] = new Vector3(0, 0, 0);
        blockRotationsLevel2[2] = new Vector3(0, 0, 90);
        blockRotationsLevel2[3] = new Vector3(0, 0, 90);
        blockRotationsLevel2[4] = new Vector3(0, 0, 90);
        blockRotationsLevel2[5] = new Vector3(0, 0, 90);
        blockRotationsLevel2[6] = new Vector3(0, 0, 0);
        blockRotationsLevel2[7] = new Vector3(0, 0, 90);
        blockRotationsLevel2[8] = new Vector3(0, 0, 90);
        

        blockScalesLevel2 = new Vector3[9];
        blockScalesLevel2[0] = new Vector3(9.5f, 1.4f, 1);
        blockScalesLevel2[1] = new Vector3(11f, 1.4f, 1);
        blockScalesLevel2[2] = new Vector3(4.15f, 1.4f, 1);
        blockScalesLevel2[3] = new Vector3(4.15f, 1.4f, 1);
        blockScalesLevel2[4] = new Vector3(4.15f, 1.4f, 1);
        blockScalesLevel2[5] = new Vector3(4.15f, 1.4f, 1);
        blockScalesLevel2[6] = new Vector3(7.5f, 1.4f, 1);
        blockScalesLevel2[7] = new Vector3(10.2f, 1.4f, 1);
        blockScalesLevel2[8] = new Vector3(10.2f, 1.4f, 1);

        enemyPositionsLevel2 = new Vector3[3];
        enemyPositionsLevel2[0] = new Vector3(9.6f, 0.6f, 1);
        enemyPositionsLevel2[1] = new Vector3(9.6f, -0.95f, 1);
        enemyPositionsLevel2[2] = new Vector3(9.6f, -2.52f, 1);

        // Level 3 Data
        blockPositionsLevel3 = new Vector3[15];
        blockPositionsLevel3[0] = new Vector3(5.3f, -3.05f, 0);
        blockPositionsLevel3[1] = new Vector3(5.3f, -1.5f, 0);
        blockPositionsLevel3[2] = new Vector3(4.6f, -2.27f, 0);
        blockPositionsLevel3[3] = new Vector3(6, -2.27f, 0);
        blockPositionsLevel3[4] = new Vector3(7.62f, -2.02f, 0);
        blockPositionsLevel3[5] = new Vector3(7.62f, 0.03f, 0);
        blockPositionsLevel3[6] = new Vector3(9.08f, 0.03f, 0);
        blockPositionsLevel3[7] = new Vector3(9.08f, -2.02f, 0);
        blockPositionsLevel3[8] = new Vector3(8.35f, -3.05f, 0);
        blockPositionsLevel3[9] = new Vector3(8.35f, 1, 0);
        blockPositionsLevel3[10] = new Vector3(8.35f, -1.05f, 0);
        blockPositionsLevel3[11] = new Vector3(11.4f, -3.05f, 0);
        blockPositionsLevel3[12] = new Vector3(11.4f, -1.5f, 0);
        blockPositionsLevel3[13] = new Vector3(10.7f, -2.27f, 0);
        blockPositionsLevel3[14] = new Vector3(12.1f, -2.27f, 0);

        blockRotationsLevel3 = new Vector3[15];
        blockRotationsLevel3[0] = new Vector3(0, 0, 0);
        blockRotationsLevel3[1] = new Vector3(0, 0, 0);
        blockRotationsLevel3[2] = new Vector3(0, 0, 90);
        blockRotationsLevel3[3] = new Vector3(0, 0, 90);
        blockRotationsLevel3[4] = new Vector3(0, 0, 90);
        blockRotationsLevel3[5] = new Vector3(0, 0, 90);
        blockRotationsLevel3[6] = new Vector3(0, 0, 90);
        blockRotationsLevel3[7] = new Vector3(0, 0, 90);
        blockRotationsLevel3[8] = new Vector3(0, 0, 0);
        blockRotationsLevel3[9] = new Vector3(0, 0, 0);
        blockRotationsLevel3[10] = new Vector3(0, 0, 0);
        blockRotationsLevel3[11] = new Vector3(0, 0, 0);
        blockRotationsLevel3[12] = new Vector3(0, 0, 0);
        blockRotationsLevel3[13] = new Vector3(0, 0, 90);
        blockRotationsLevel3[14] = new Vector3(0, 0, 90);
        

        blockScalesLevel3 = new Vector3[15];
        blockScalesLevel3[0] = new Vector3(7f, 1.4f, 1);
        blockScalesLevel3[1] = new Vector3(7f, 1.4f, 1);
        blockScalesLevel3[2] = new Vector3(4.1f, 1.4f, 1);
        blockScalesLevel3[3] = new Vector3(4.1f, 1.4f, 1);
        blockScalesLevel3[4] = new Vector3(5.65f, 1.4f, 1);
        blockScalesLevel3[5] = new Vector3(5.65f, 1.4f, 1);
        blockScalesLevel3[6] = new Vector3(5.65f, 1.4f, 1);
        blockScalesLevel3[7] = new Vector3(5.65f, 1.4f, 1);
        blockScalesLevel3[8] = new Vector3(7, 1.4f, 1);
        blockScalesLevel3[9] = new Vector3(7, 1.4f, 1);
        blockScalesLevel3[10] = new Vector3(7, 1.4f, 1);
        blockScalesLevel3[11] = new Vector3(7, 1.4f, 1);
        blockScalesLevel3[12] = new Vector3(7, 1.4f, 1);
        blockScalesLevel3[13] = new Vector3(4.1f, 1.4f, 1);
        blockScalesLevel3[14] = new Vector3(4.1f, 1.4f, 1);

        enemyPositionsLevel3 = new Vector3[5];
        enemyPositionsLevel3[0] = new Vector3(8.35f, -0.45f, 1);
        enemyPositionsLevel3[1] = new Vector3(8.35f, -2.5f, 1);
        enemyPositionsLevel3[2] = new Vector3(8.35f, 1.6f, 1);
        enemyPositionsLevel3[3] = new Vector3(11.4f, -2.52f, 1);
        enemyPositionsLevel3[4] = new Vector3(5.28f, -2.52f, 1);
    }

    public void SetupLevel(Vector3 playerSpawnPosition, Vector3[] blockPositions, Vector3[] blockRotations, Vector3[] blockScales, Vector3[] enemyPositions)
    {
        // playerSpawner.SpawnPlayer(playerSpawnPosition);
        blockSpawner.SpawnBlocks(blockPositions, blockRotations, blockScales);
        enemySpawner.SpawnEnemies(enemyPositions);
    }
}

