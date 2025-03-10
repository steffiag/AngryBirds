using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager: MonoBehaviour, ITimerObserver
{
    private Timer timer;
    private Dictionary<int, string> levels = new Dictionary<int, string>();
    private string currentScene;
    public GameObject mainMenuButton;
    public GameObject gameOverText;

    public GameObject GameOverWinText;
    public GameObject nextLevelButton;

    
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        levels.Add(1, "Level 1");
        levels.Add(2, "Level 2");
        levels.Add(3, "Level 3");
        timer.Subscribe(this);
    }

    public void TimerEvent(){
        // if won
        GameOver(false);
    }

    public void GameOver(bool isWinner){
        if (isWinner){
            GameOverWinText.SetActive(true);
            nextLevelButton.SetActive(true);
        }
        else{
            mainMenuButton.SetActive(true);
            gameOverText.SetActive(true);
        }
        timer.Unsubscribe(this);
    }

     public void GoBacktoMenu()
    {
        //SceneManager.LoadScene("");
    }

    public void NextLevel()
    {
        int newSceneCount = 0;
        currentScene = SceneManager.GetActiveScene().name;
        for (int i = 1; i<=levels.Count; i++){
            if (levels[i] == currentScene){
                newSceneCount = i + 1;
                break;
            }
        }
        if (newSceneCount <= 3){
            
            SceneManager.LoadScene(levels[newSceneCount]);
        }
        else{
            GoBacktoMenu();
        }
        
    }

}
