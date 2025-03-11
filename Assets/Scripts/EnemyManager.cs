using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    bool finished;
    private GameOverManager gameOverManager;

    void Start(){
        gameOverManager = FindObjectOfType<GameOverManager>();
        
    }
    void Update()
    {
        CheckIfNoEnemiesLeft();
    }

    void CheckIfNoEnemiesLeft(){
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        bool no_enemies = true;
        for (int i = 0; i<enemies.Length; i++){
            if (enemies[i].gameObject.activeInHierarchy){
                no_enemies = false;
            }
        }
        if (no_enemies && !finished){
            gameOverManager.GameOver(true);
            finished = true;
        }
    }
}
