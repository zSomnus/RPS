using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TimerState timerState;

    private float timerDuration;
    private float currentTime;

    public Action OnTimerStop;
    

    public void SetUp(float duration)
    {
        timerDuration = duration;
    }

    public void Run()
    {
        if (timerState == TimerState.STOP)
        {
            timerState = TimerState.RUNNING;
            currentTime = timerDuration;
        }
    }
    private void Update()
    {
        if (timerState == TimerState.RUNNING && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0 && timerState == TimerState.RUNNING)
            {
                timerState = TimerState.STOP;
                OnTimerStop?.Invoke();
            }
        }
    }

}


public enum TimerState
{
    STOP, RUNNING
}
