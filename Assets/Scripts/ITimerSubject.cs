using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimerSubject
{
    public void Subscribe(ITimerObserver o);

    public void Unsubscribe(ITimerObserver o);
}
