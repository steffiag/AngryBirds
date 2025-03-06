using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer: MonoBehaviour, ITimerSubject
{
    public float timeRemaining = 30f;
    private List<ITimerObserver> observers = new List<ITimerObserver>();
    public Text timerText;
    private bool isGameActive = true;

    // Update is called once per frame
    void Update()
    {
        if (isGameActive){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                timerText.text = Mathf.FloorToInt(timeRemaining/60).ToString("00") + ":" + (Mathf.FloorToInt(timeRemaining%60)).ToString("00");
            }
            if (timeRemaining <= 0){
                timerText.text = Mathf.FloorToInt(0).ToString("00") + ":" + (Mathf.FloorToInt(0)).ToString("00");
                isGameActive = false;
                SendMessage();
                
            }
        }
        
    }
    public void Subscribe(ITimerObserver o){
        observers.Add(o);
    }

    public void Unsubscribe(ITimerObserver o){
        observers.Remove(o);
    }

    public void SendMessage(){
        for (int i = 0; i<observers.Count; i++){
            observers[i].TimerEvent();
        }
    }
}
