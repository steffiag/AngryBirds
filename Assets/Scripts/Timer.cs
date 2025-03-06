using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer: ITimerSubject
{
    public float timeRemaining = 30f;
    private List<ITimerObserver> observers = new List<ITimerObserver>();

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0){
            SendMessage();
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
