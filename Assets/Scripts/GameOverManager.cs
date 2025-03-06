using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager: MonoBehaviour, ITimerObserver
{
    protected ITimerSubject timer = new Timer();
    // Start is called before the first frame update
    void Start()
    {
        timer.Subscribe(this);
    }

    public void TimerEvent(){
        // if won
        GameOver(true);
        // else
        GameOver(false);
    }
    public void GameOver(bool isWinner){
        if (isWinner){
            // win screen
        }
        else{
            // lose screen
        }
        timer.Unsubscribe(this);
    }
}
