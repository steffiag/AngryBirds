using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer: MonoBehaviour, ITimerSubject
{
    public float timeRemaining = 30f;
    public List<ITimerObserver> observers = new List<ITimerObserver>();
    public Text timerText;
    private bool isGameActive = true;

    void Awake(){
        observers.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateTime(){
        if (isGameActive){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                timerText.text = Mathf.FloorToInt(timeRemaining/60).ToString("00") + ":" + (Mathf.FloorToInt(timeRemaining%60)).ToString("00");
            }
            if (timeRemaining <= 0){
                timeRemaining = 0;
                timerText.text = Mathf.FloorToInt(0).ToString("00") + ":" + (Mathf.FloorToInt(0)).ToString("00");
                SendMessage();
                isGameActive = false;
                
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
        Debug.Log(observers.Count);
        for (int i = 0; i<observers.Count; i++){
            observers[i].TimerEvent();
        }
    }
}
